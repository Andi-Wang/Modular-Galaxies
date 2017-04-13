using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialContentManager : ContentManager {
    private void Awake() {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetChild(1).GetComponentInChildren<Text>().text = Special.name(i);
            transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text = Special.drain(i).ToString();
            transform.GetChild(i).GetChild(3).GetComponentInChildren<Text>().text = Special.cooldown(i).ToString();
            transform.GetChild(i).GetChild(4).GetComponentInChildren<Text>().text = Special.complexity(i).ToString();
            transform.GetChild(i).GetChild(5).GetComponentInChildren<Text>().text = Special.weight(i).ToString();
        }
    }

    protected override bool ownedCheck(int index) {
        return hangarScript.specialOwned[index];
    }

    protected override bool hideCondition(int index) {
        return (!ownedCheck(index) || hangarScript.selectedFrame != (index + Special.NUM_PER_FRAME - 1) / Special.NUM_PER_FRAME) && index > 0;
    }
}
