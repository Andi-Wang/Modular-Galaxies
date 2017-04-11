using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShip : MonoBehaviour {
    protected float maxHealth;
    protected float health;

    protected float maxEnergy;
    protected float energy;
    protected float energyRegeneration;
    protected bool solarCell;
    protected bool fuelCell;  

    protected float speed;
    
    protected Weapon weapon;
    protected Special module;

    public GameObject shipPrefab;
    



    /*
    protected void Awake() {
        setStats();
        shipPrefab.transform.FindChild("PlayerHitbox").localScale = new Vector3(hitboxRadius, hitboxRadius);
        shipPrefab.transform.FindChild("PlayerGrazebox").localScale = new Vector3(grazeboxRadius, grazeboxRadius);
    }*/



    protected void takeDamage(float amount) {
        health -= amount;
    }

    protected void graze(float amount) {
        energy += amount;
    }



    /*
    protected virtual void setStats() {
        health = baseHealth + Armor.health(armorTier);
        energy = Reactor.capacity(reactorTier);
        hitboxRadius = 1;
        grazeboxRadius = 1;
        speedModifier = 1;

        computerTier = 1;
        engineTier = 1;
        reactorTier = 1;
        armorTier = 1;
    }
    */




}
