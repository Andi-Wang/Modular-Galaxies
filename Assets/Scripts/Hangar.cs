using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hangar : MonoBehaviour {
    //Base stats associated with the base ship
    private float spaceLimit;
    private float weightLimit;
    private float speedModifier;
    private float baseHealth;
    private float hitboxRadius;
    private float grazeboxRadius; //Narrowly avoiding projectiles, or "grazing", restores some energy (lore: by draining it from the projectile); implement in GrazeboxController by checking when a projectile leaves the graze area

    //Equipped modules
    private int computerTier;
    private int engineTier;
    private int energyTier;
    private int armorTier;
    private Weapon weapon;
    private Special special;

    //Selected modules
    public int selectedFrame { private set; get; }
    public int selectedComputer { private set; get; }
    public int selectedEngine { private set; get; }
    public int selectedEnergy { private set; get; }
    public int selectedWeapon { private set; get; }
    public int selectedArmor { private set; get; }
    public int selectedSpecial { private set; get; }

    //Owned modules
    public bool[] frameOwned { private set; get; }
    public bool[] computerOwned { private set; get; }
    public bool[] engineOwned { private set; get; }
    public bool[] energyOwned { private set; get; }
    public bool[,] armorOwned { private set; get; }
    public bool[,] weaponOwned { private set; get; }
    public bool[,] specialOwned { private set; get; }


    //After choosing a valid ship, creates a PlayerShip and attaches it to this playerManager
    public GameObject playerManager;

    public Image selectPanel;
    public Image modulePanel;

    public Text weight;
    public Text space;
    public Text complexity;



    private void Awake() {
        frameOwned = new bool[13];
        computerOwned = new bool[13];
        engineOwned = new bool[13];
        energyOwned = new bool[13];
        armorOwned = new bool[3, 13];
        weaponOwned = new bool[frameOwned.Length, 13];
        specialOwned = new bool[frameOwned.Length, 13];

        for(int i = 0; i < 13; i++) {
            frameOwned[i] = true;
            computerOwned[i] = true;
            engineOwned[i] = true;
            energyOwned[i] = true;
            armorOwned[0, i] = true;
            armorOwned[1, i] = true;
            armorOwned[2, i] = true;
            for(int j = 0; j < 13; j++) {
                weaponOwned[j, i] = true;
                specialOwned[j, i] = true;
            }
        }
    }


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



    private void confirm () {
        if(validateSpace() && validateWeight() && validateComplexity()) {

        }
        else {
            //play error sound or message
        }
    }









    public void toggleFrame(Toggle source) {
        selectedFrame = source.gameObject.transform.GetSiblingIndex();
        toggleColorChange(source);
    }
    public void toggleComputer(Toggle source) {
        selectedComputer = source.gameObject.transform.GetSiblingIndex();
        toggleColorChange(source);
    }
    public void toggleEngine(Toggle source) {
        selectedEngine = source.gameObject.transform.GetSiblingIndex();
        toggleColorChange(source);
    }
    public void toggleEnergy(Toggle source) {
        selectedEnergy = source.gameObject.transform.GetSiblingIndex();
        toggleColorChange(source);
    }
    public void toggleWeapon(Toggle source) {
        selectedWeapon = source.gameObject.transform.GetSiblingIndex();
        toggleColorChange(source);
    }
    public void toggleArmor(Toggle source) {
        selectedArmor = source.gameObject.transform.GetSiblingIndex();
        toggleColorChange(source);
    }
    public void toggleSpecial(Toggle source) {
        selectedSpecial = source.gameObject.transform.GetSiblingIndex();
        toggleColorChange(source);
    }






    private void toggleColorChange(Toggle source) {
        Image appearance = source.gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<Image>();
        Color color = appearance.color;
        float alpha = 1f;

        if (source.isOn) {
            for (int i = 1; i < source.transform.childCount; i++) {
                Text text = source.gameObject.transform.GetChild(i).GetComponentInChildren<Text>();
                if (text) {
                    text.color = Color.green;
                }
            }
        }
        else {
            alpha = 128f / 255f;

            for (int i = 1; i < source.transform.childCount; i++) {
                Text text = source.gameObject.transform.GetChild(i).GetComponentInChildren<Text>();
                if (text) {
                    text.color = new Color(150f / 255f, 160f / 255f, 180f / 255f);
                }
            }
        }

        appearance.color = new Color(color.r, color.g, color.b, alpha);
    }

    private bool validateSpace() {
        return spaceLimit >= Engine.space(engineTier) + Armor.space(0, armorTier);
    }
    private bool validateWeight() {
        return weightLimit >= Computer.weight(computerTier) + Engine.weight(engineTier) + Energy.weight(energyTier) + Armor.weight(0, armorTier) + weapon.weight + special.weight;
    }
    private bool validateComplexity() {
        return Computer.complexity(computerTier) >= weapon.complexity + special.complexity;
    }
}
