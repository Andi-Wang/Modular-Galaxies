using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyContentManager : ContentManager {

    // Use this for initialization
    private void Awake() {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetChild(1).GetComponentInChildren<Text>().text = Energy.name(i);
            transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text = Energy.typeName(Energy.type(i));
            transform.GetChild(i).GetChild(3).GetComponentInChildren<Text>().text = Energy.capacity(i).ToString();
            transform.GetChild(i).GetChild(4).GetComponentInChildren<Text>().text = Energy.regen(i).ToString();
            transform.GetChild(i).GetChild(5).GetComponentInChildren<Text>().text = Energy.weight(i).ToString();
        }
    }

    protected override bool ownedCheck(int index) {
        return hangarScript.energyOwned[index];
    }
}
