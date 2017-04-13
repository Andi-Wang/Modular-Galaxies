using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManager : MonoBehaviour {
    public Hangar hangarScript;
    protected float updateTimer = 2f;
    protected int numColumns = 6;

    private void Update() {
        if (updateTimer > 1f) {
            updateShown();
            updateTimer = 0f;
        }
        else {
            updateTimer += Time.deltaTime;
        }
    }

    private void onDisable() {
        updateTimer = 2f;
    }
    private void onEnable() {
        updateShown();
    }

    private void updateShown() {
        for (int i = 0; i < transform.childCount; i++) {
            if (hideCondition(i)) {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            else {
                transform.GetChild(i).gameObject.SetActive(true);

                for (int j = 0; j < transform.GetChild(i).childCount; j++) {
                    if (j >= numColumns) {
                        transform.GetChild(i).GetChild(j).GetChild(0).gameObject.SetActive(false);
                    }
                    else {
                        transform.GetChild(i).GetChild(j).GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    protected virtual bool ownedCheck(int index) {
        return false;
    }

    protected virtual bool hideCondition(int index) {
        return !ownedCheck(index);
    }
}
