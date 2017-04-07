using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    protected float spaceLimit;
    protected float weightLimit;

    protected float baseHealth;
    protected float speedModifier;

    protected int computerTier;
    protected int engineTier;
    protected int reactorTier;
    protected int armorTier;

    protected Weapon weapon;
    protected UtilityModule module;

    public GameObject shipPrefab;
    public GameObject hitboxPrefab;
    public GameObject grazeboxPrefab;    //Narrowly avoiding projectiles, or "grazing", restores some energy (lore: by draining it from the projectile); implement in GrazeboxController by checking when a projectile leaves the graze area

    protected float health;




    protected void takeDamage(float amount) {
        health -= amount;
    }



    protected void setInitialHealth() {
        health = baseHealth + Armor.health(armorTier);
    }





    protected bool validateSpace() {
        return spaceLimit >= Computer.space(computerTier) + Engine.space(engineTier) + Reactor.space(reactorTier) + Armor.space(armorTier) + weapon.space + module.space;
    }

    protected bool validateWeight() {
        return weightLimit >= Computer.weight(computerTier) + Engine.weight(engineTier) + Reactor.weight(reactorTier) + Armor.weight(armorTier) + weapon.weight + module.weight;
    }

    protected bool validateComplexity() {
        return Computer.complexity(computerTier) >= Engine.complexity(engineTier) + Reactor.complexity(reactorTier) + weapon.complexity + module.complexity;
    }
}
