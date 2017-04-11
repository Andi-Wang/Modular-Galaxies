using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hangar : MonoBehaviour {
    //Base stats associated with the base ship
    protected float spaceLimit;
    protected float weightLimit;
    protected float speedModifier;
    protected float baseHealth;
    protected float hitboxRadius;
    protected float grazeboxRadius; //Narrowly avoiding projectiles, or "grazing", restores some energy (lore: by draining it from the projectile); implement in GrazeboxController by checking when a projectile leaves the graze area

    //Equipped modules
    protected int computerTier;
    protected int engineTier;
    protected int reactorTier;
    protected int armorTier;   
    protected Weapon weapon;
    protected Special special;

    protected int shipSize;

    //After choosing a valid ship, creates a PlayerShip and attaches it to this playerManager
    public GameObject playerManager;

    public Image selectPanel;
    public Image modulePanel;

    public Text weight;
    public Text space;
    public Text complexity;


    private void Update() {
        for(int i = 0; i < selectPanel.transform.childCount; i++) {
            if(selectPanel.transform.GetChild(i).GetComponent<Toggle>().isOn) {
                modulePanel.transform.GetChild(i).gameObject.SetActive(true);
            }
            else {
                modulePanel.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }



    protected void confirm () {
        if(validateSpace() && validateWeight() && validateComplexity()) {

        }
        else {
            //play error sound or message
        }
    }









    protected bool validateSpace() {
        return spaceLimit >= Engine.space(engineTier) + Armor.space(shipSize, armorTier);
    }

    protected bool validateWeight() {
        return weightLimit >= Computer.weight(computerTier) + Engine.weight(engineTier) + Energy.weight(reactorTier) + Armor.weight(shipSize, armorTier) + weapon.weight + special.weight;
    }

    protected bool validateComplexity() {
        return Computer.complexity(computerTier) >= weapon.complexity + special.complexity;
    }
}
