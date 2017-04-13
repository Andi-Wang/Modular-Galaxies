using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerContentManager : ContentManager {
    // Use this for initialization
    private void Awake() {
        numColumns = 4;
        for(int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetChild(1).GetComponentInChildren<Text>().text = Computer.name(i);
            transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text = Computer.complexity(i).ToString();
            transform.GetChild(i).GetChild(3).GetComponentInChildren<Text>().text = Computer.weight(i).ToString();
        }
    }

    protected override bool ownedCheck(int index) {
        return hangarScript.computerOwned[index];
    }
}
