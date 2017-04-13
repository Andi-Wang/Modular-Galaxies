using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponContentManager : ContentManager {
    private void Awake() {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetChild(1).GetComponentInChildren<Text>().text = Weapon.name(i);
            transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text = Weapon.drain(i).ToString();
            transform.GetChild(i).GetChild(3).GetComponentInChildren<Text>().text = Weapon.cooldown(i).ToString();
            transform.GetChild(i).GetChild(4).GetComponentInChildren<Text>().text = Weapon.complexity(i).ToString();
            transform.GetChild(i).GetChild(5).GetComponentInChildren<Text>().text = Weapon.weight(i).ToString();
        }
    }

    protected override bool ownedCheck(int index) {
        return hangarScript.weaponOwned[index];
    }

    protected override bool hideCondition(int index) {
        return (!ownedCheck(index) || hangarScript.selectedFrame != (index + Weapon.NUM_PER_FRAME - 1) / Weapon.NUM_PER_FRAME) && index > 0;
    }
}
