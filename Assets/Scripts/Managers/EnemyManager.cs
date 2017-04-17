using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    private Camera mainCamera;

	protected void Awake() {
        mainCamera = gameObject.GetComponentInParent<GameManager>().mainCamera;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
