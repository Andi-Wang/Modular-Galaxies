using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hangar : MonoBehaviour {
    //Base stats associated with the base ship
    private float hitboxRadius;
    private float grazeboxRadius; //Narrowly avoiding projectiles, or "grazing", restores some energy (lore: by draining it from the projectile); implement in GrazeboxController by checking when a projectile leaves the graze area

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
    public bool[] armorOwned { private set; get; }
    public bool[] weaponOwned { private set; get; }
    public bool[] specialOwned { private set; get; }


    //After choosing a valid ship, creates a PlayerShip and attaches it to this playerManager
    public UnityStandardAssets._2D.PlayerInput playerManager;
    public GameObject playerShipPool;

    public Image selectPanel;
    public Image modulePanel;

    public Text weight;
    public Text space;
    public Text complexity;

    private Color textColor = new Color(150f / 255f, 160f / 255f, 180f / 255f);



    private void Awake() {
        frameOwned = new bool[1 + 18 * Frame.MAX_MK];
        computerOwned = new bool[13];
        engineOwned = new bool[13];
        energyOwned = new bool[13];
        armorOwned = new bool[1 + 3 * Armor.MODULES_PER_SIZE];
        weaponOwned = new bool[1 + frameOwned.Length * Weapon.NUM_PER_FRAME];
        specialOwned = new bool[1 + frameOwned.Length * Special.NUM_PER_FRAME];

        frameOwned[0] = true;
        weaponOwned[0] = true;
        specialOwned[0] = true;

        /*
        for(int i = 1; i <= 18; i++) {
            frameOwned[i * Frame.MAX_MK] = true;
        }*/

        for(int i = 0; i < frameOwned.Length; i++) {
            frameOwned[i] = true;
        }

        for (int i = 0; i < armorOwned.Length; i++) { armorOwned[i] = true; }
        for (int i = 0; i < weaponOwned.Length; i++) { weaponOwned[i] = true; }
        for (int i = 0; i < specialOwned.Length; i++) { specialOwned[i] = true; }

        for (int i = 0; i < 13; i++) {
            computerOwned[i] = true;
            engineOwned[i] = true;
            energyOwned[i] = true;
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
            GameObject activeShip = null;
            for(int i = 0; i < playerShipPool.transform.childCount; i++) {
                if(i == Frame.model(selectedFrame) - 1) {
                    activeShip = playerShipPool.transform.GetChild(i).gameObject;
                    activeShip.SetActive(true);
                    activeShip.transform.position = new Vector2();
                }
                else {
                    playerShipPool.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
                   
            if(activeShip) {
                playerManager.player = activeShip.GetComponent<Ship>();
                playerManager.player.setStatistics(selectedFrame, selectedEngine, selectedEnergy, selectedArmor, selectedWeapon, selectedSpecial);
            }

            gameObject.SetActive(false);
        }
        else {
            //play error sound or message
        }
    }









    public void toggleFrame(Toggle source) {
        selectedFrame = source.gameObject.transform.GetSiblingIndex();
        updateLimits();
        toggleColorChange(source);
    }
    public void toggleComputer(Toggle source) {
        selectedComputer = source.gameObject.transform.GetSiblingIndex();
        updateLimits();
        toggleColorChange(source);
    }
    public void toggleEngine(Toggle source) {
        selectedEngine = source.gameObject.transform.GetSiblingIndex();
        updateLimits();
        toggleColorChange(source);
    }
    public void toggleEnergy(Toggle source) {
        selectedEnergy = source.gameObject.transform.GetSiblingIndex();
        updateLimits();
        toggleColorChange(source);
    }
    public void toggleWeapon(Toggle source) {
        selectedWeapon = source.gameObject.transform.GetSiblingIndex();
        updateLimits();
        toggleColorChange(source);
    }
    public void toggleArmor(Toggle source) {
        selectedArmor = source.gameObject.transform.GetSiblingIndex();
        updateLimits();
        toggleColorChange(source);
    }
    public void toggleSpecial(Toggle source) {
        selectedSpecial = source.gameObject.transform.GetSiblingIndex();
        updateLimits();
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
                    text.color = textColor;
                }
            }
        }

        appearance.color = new Color(color.r, color.g, color.b, alpha);
    }

    private bool validateSpace() {
        return Frame.space(selectedFrame) >= Engine.space(selectedEngine) + Armor.space(selectedArmor);
    }
    private bool validateWeight() {
        return Frame.weight(selectedFrame) >= Computer.weight(selectedComputer) + Engine.weight(selectedEngine) + Energy.weight(selectedEnergy) + Armor.weight(selectedArmor) + Weapon.weight(selectedWeapon) + Special.weight(selectedSpecial);
    }
    private bool validateComplexity() {
        return Computer.complexity(selectedComputer) >= Weapon.complexity(selectedWeapon) + Special.complexity(selectedSpecial);
    }
    private void updateLimits() {
        space.text = Engine.space(selectedEngine) + Armor.space(selectedArmor) + " / " + Frame.space(selectedFrame);
        weight.text = Computer.weight(selectedComputer) + Engine.weight(selectedEngine) + Energy.weight(selectedEnergy) + Armor.weight(selectedArmor) + Weapon.weight(selectedWeapon) /*+ special.weight*/ + " / " + Frame.weight(selectedFrame);
        complexity.text = Weapon.complexity(selectedWeapon) + Special.complexity(selectedSpecial) + " / " + Computer.complexity(selectedComputer);

        if (!validateSpace()) { space.color = Color.red; }
        else { space.color = textColor; }

        if (!validateWeight()) { weight.color = Color.red; }
        else { weight.color = textColor; }

        if (!validateComplexity()) { complexity.color = Color.red; }
        else { complexity.color = textColor; }
    }
}
