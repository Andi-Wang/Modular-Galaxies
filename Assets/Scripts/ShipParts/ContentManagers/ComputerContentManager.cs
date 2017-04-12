using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerContentManager : MonoBehaviour {
    public Hangar hangarScript;
    private float updateTimer;
    private const int maxColumnIndex = 3;

    // Use this for initialization
    private void Awake() {
        updateTimer = 2f;
        for(int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetChild(1).GetComponentInChildren<Text>().text = Computer.name(i);
            transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text = Computer.complexity(i).ToString();
            transform.GetChild(i).GetChild(3).GetComponentInChildren<Text>().text = Computer.weight(i).ToString();
        }
    }

    private void Update() {
        if (updateTimer > 1f) {
            for (int i = 0; i < transform.childCount; i++) {
                for (int j = 0; j < transform.GetChild(i).childCount; j++) {
                    if (!hangarScript.computerOwned[i] || j > maxColumnIndex) {
                        transform.GetChild(i).GetChild(j).GetChild(0).gameObject.SetActive(false);
                    }
                    else {
                        transform.GetChild(i).GetChild(j).GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
            updateTimer = 0f;
        }
        else {
            updateTimer += Time.deltaTime;
        }
    }
}
