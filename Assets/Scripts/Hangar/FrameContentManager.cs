using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameContentManager : ContentManager {
    private void Awake() {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetChild(1).GetComponentInChildren<Text>().text = Frame.name(i);
            transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text = Frame.sizeName(Frame.size(i));
            transform.GetChild(i).GetChild(3).GetComponentInChildren<Text>().text = Frame.health(i).ToString();
            transform.GetChild(i).GetChild(4).GetComponentInChildren<Text>().text = Frame.weight(i).ToString();
            transform.GetChild(i).GetChild(5).GetComponentInChildren<Text>().text = Frame.space(i).ToString();
        }
    }

    protected override bool ownedCheck(int index) {
        return hangarScript.frameOwned[index];
    }
}
