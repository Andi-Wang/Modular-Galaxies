using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Lark : Ship {
    private bool specialToggle = false;
    private GameObject projectile;
    private const float maxWidth = 0.45f, spoolupTime = 3f, specialMaxWidth = 0.7f, specialSpoolupTime = 2.5f, minDamage = 0.5f, specialMoveSpeed = 0.7f;
    private float width = 0f;

    public override void move(PlayerInput.Input input) {
        if (input.specialDown) {
            specialToggle = !specialToggle;
        }

        //Move the ship; moves slower if special ability is activated
        if (!specialToggle) {
            gameObject.transform.position += new Vector3(input.horizontal * speed * Time.fixedDeltaTime, input.vertical * speed * Time.fixedDeltaTime);
        }
        else {
            gameObject.transform.position += new Vector3(input.horizontal * specialMoveSpeed * speed * Time.fixedDeltaTime, input.vertical * specialMoveSpeed * speed * Time.fixedDeltaTime);
        }

        if (input.fireDown || input.fireHold) {
            useWeapon();
            if (!specialToggle) {
                width = Mathf.Min(width + maxWidth / spoolupTime * Time.fixedDeltaTime, maxWidth);
            }
            else {
                width = Mathf.Min(width + specialMaxWidth / specialSpoolupTime * Time.fixedDeltaTime, specialMaxWidth);
            }
        }
        else if (input.fireUp) {
            SimplePool.Despawn(projectile);
            projectile = null;
            width = 0f;
        }
    }

    public override void clampToCameraBound(Camera camera) {
        base.clampToCameraBound(camera);
        if(projectile) {
            float screenTop = camera.transform.position.y + camera.orthographicSize;
            float projectileTargetHeight = screenTop - gameObject.transform.position.y;
            float projectileVerticalScale = projectileTargetHeight / projectile.GetComponent<BoxCollider2D>().size.y;

            projectile.transform.position = new Vector3(transform.position.x, (screenTop + transform.position.y) / 2);
            projectile.transform.localScale = new Vector3(width, projectileVerticalScale);
        }
    }


    protected override void useWeapon() {
        if (!specialToggle) {
            if (weaponCooldown <= 0 && energyCost(weaponDrain)) {
                weaponEffect();
                weaponCooldown = weaponMaxCooldown;
            }
        }
        else {
            if (weaponCooldown <= 0 && energyCost(weaponDrain * Special.drain(specialTier))) {
                weaponEffect();
                weaponCooldown = weaponMaxCooldown;
            }
        }
    }
    
    protected override void weaponEffect() {
        if (!projectile) {
            projectile = SimplePool.Spawn(weaponPrefab, transform.position, new Quaternion());
        }

        if (!specialToggle) {
            projectile.GetComponent<ProjectileController>().setDamage(weaponDamage * (minDamage + (width / maxWidth) * (1 - minDamage)));
        }
        else {
            projectile.GetComponent<ProjectileController>().setDamage((minDamage * (minDamage + (width / specialMaxWidth) * (1 - minDamage)) * (1 + specialPower)));
        }

        //Laser deals damage in pulses, not on collision; collider is occasionally enabled for an instant to deal damage
        projectile.GetComponent<Collider2D>().enabled = true;
        projectile.GetComponent<Collider2D>().enabled = false;
    }
}
