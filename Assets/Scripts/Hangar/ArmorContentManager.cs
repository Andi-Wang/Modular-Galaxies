using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorContentManager : ContentManager {

	// Use this for initialization
    private void Awake() {
        numColumns = 5;
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetChild(1).GetComponentInChildren<Text>().text = Armor.name(i);
            transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text = Armor.health(i).ToString();
            transform.GetChild(i).GetChild(3).GetComponentInChildren<Text>().text = Armor.weight(i).ToString();
            transform.GetChild(i).GetChild(4).GetComponentInChildren<Text>().text = Armor.space(i).ToString();
        }
    }

    protected override bool ownedCheck(int index) {
        return hangarScript.armorOwned[index];
    }

    protected override bool hideCondition(int index) {
        return (!ownedCheck(index) || Frame.size(hangarScript.selectedFrame) != (index - 1) / Armor.MODULES_PER_SIZE) && index > 0;
    }
}
