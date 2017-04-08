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
    Weapon weapon;
    UtilityModule module;

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
        return spaceLimit >= Computer.space(computerTier) + Engine.space(engineTier) + Reactor.space(reactorTier) + Armor.space(armorTier) + weapon.space + module.space;
    }

    protected bool validateWeight() {
        return weightLimit >= Computer.weight(computerTier) + Engine.weight(engineTier) + Reactor.weight(reactorTier) + Armor.weight(armorTier) + weapon.weight + module.weight;
    }

    protected bool validateComplexity() {
        return Computer.complexity(computerTier) >= Engine.complexity(engineTier) + Reactor.complexity(reactorTier) + weapon.complexity + module.complexity;
    }
}
