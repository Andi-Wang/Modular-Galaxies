using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineContentManager : ContentManager {
    // Use this for initialization
    private void Awake() {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetChild(1).GetComponentInChildren<Text>().text = Engine.name(i);
            transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text = Engine.typeName(Engine.type(i));
            transform.GetChild(i).GetChild(3).GetComponentInChildren<Text>().text = Engine.speed(i, Frame.weight(hangarScript.selectedFrame), Frame.size(hangarScript.selectedFrame)).ToString();
            transform.GetChild(i).GetChild(4).GetComponentInChildren<Text>().text = Engine.weight(i).ToString();
            transform.GetChild(i).GetChild(5).GetComponentInChildren<Text>().text = Engine.space(i).ToString();
        }
    }

    protected override bool ownedCheck(int index) {
        return hangarScript.engineOwned[index];
    }
}
