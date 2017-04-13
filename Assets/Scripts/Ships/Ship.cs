using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    protected float maxHealth;
    protected float maxEnergy;
    protected float energyRegen;
    public float energyType { protected set; get; }
    protected float speed;
    protected float engineType;
    protected float weaponDrain;
    protected float weaponMaxCooldown;
    protected float specialDrain;
    protected float specialMaxCooldown;

    protected float health;
    protected float energy;
    protected float weaponCooldown;
    protected float specialCooldown;

    public GameObject weaponPrefab;
    public GameObject specialPrefab;

    public virtual void move(UnityStandardAssets._2D.PlayerInput.Input input) {
        weaponCooldown += Time.fixedDeltaTime;
        specialCooldown += Time.fixedDeltaTime;

        if(input.fireDown || input.fireHold) {
            useWeapon();
        }
        if(input.specialDown || input.specialHold) {
            useSpecial();
        }

        gameObject.transform.position += new Vector3(input.horizontal * speed, input.vertical * speed, 0);
    }

    protected virtual void weaponEffect() {
        //Debug.Log("Weapon activated!");
        GameObject projectile = SimplePool.Spawn(weaponPrefab, transform.position, new Quaternion());
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
    }
    protected virtual void specialEffect() {
        Debug.Log("Special activated!");
    }

    public void takeDamage(float amount) {
        health -= amount;

        if(health <= 0) {
            //Player dies
        }
    }

    protected void useWeapon() {
        if(weaponCooldown >= weaponMaxCooldown && energy >= weaponDrain) {
            weaponEffect();
            weaponCooldown = 0;
            energy -= weaponDrain;
        }
    }
    protected void useSpecial() {
        if(specialCooldown >= specialMaxCooldown && energy >= specialDrain) {
            specialEffect();
            specialCooldown = 0;
            energy -= specialDrain;
        }        
    }

    // Design for engine functionality still incomplete
    public void useEngine() {
        if(engineType == Engine.FIRE) {
            Debug.Log("Fire engine activated!");
        }
        else if(engineType == Engine.WIND) {
            Debug.Log("Wind engine activated!");
        }
    }

    public void setStatistics(int frame, int engine, int energy, int armor, int weapon, int special) {
        maxHealth = Frame.health(frame);
        maxEnergy = Energy.capacity(energy);
        energyRegen = Energy.regen(energy);
        energyType = Energy.type(energy);
        speed = Engine.speed(engine, Frame.weight(frame), Frame.size(frame));
        engineType = Engine.type(engine);
        weaponDrain = Weapon.drain(weapon);
        weaponCooldown = Weapon.cooldown(weapon);
        specialDrain = Special.drain(special);
        specialCooldown = Special.cooldown(special);

        health = maxHealth;
        this.energy = maxEnergy;
        weaponCooldown = weaponMaxCooldown;
        specialCooldown = specialMaxCooldown;
    }
}
