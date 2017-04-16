using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparrow : Ship {
    private bool specialToggle = false;
    private bool fireLeft = false;

    protected override bool specialCheck(bool specialDown, bool specialHold) {
        return specialDown;
    }


    protected override void weaponEffect() {
        GameObject projectile;
        if (!specialToggle) {
            projectile = SimplePool.Spawn(weaponPrefab, transform.position + Vector3.up * .1f, new Quaternion());
            projectile.GetComponent<ProjectileController>().setDamage(weaponDamage);
        }
        else {
            Vector3 origin = transform.position;
            if(fireLeft) { origin += (Vector3.left + Vector3.up) * .1f; }
            else { origin += (Vector3.right + Vector3.up) * .1f; }
            fireLeft = !fireLeft;

            projectile = SimplePool.Spawn(specialPrefab, origin, new Quaternion());
            projectile.GetComponent<ProjectileController>().setDamage(weaponDamage * Special.power(specialTier));
        }
        
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
    }
    protected override void useSpecial() {
        specialToggle = !specialToggle;
    }
    protected override void useWeapon() {
        if(!specialToggle) {
            if (weaponCooldown <= 0 && energyCost(weaponDrain)) {
                weaponEffect();
                weaponCooldown = weaponMaxCooldown;
            }
        }
        else {
            if (weaponCooldown <= 0 && energyCost(weaponDrain * Special.drain(specialTier))) {
                weaponEffect();
                weaponCooldown = weaponMaxCooldown * (1 + Special.cooldown(specialTier));
            }
        }
        
    }
}
