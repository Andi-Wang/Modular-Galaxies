using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float cameraScrollSpeed = 0f;
    public float xMin { private set; get; }
    public float xMax { private set; get; }
    public float yMin { private set; get; }
    public float yMax { private set; get; }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(0, cameraScrollSpeed * Time.fixedDeltaTime);

	}
}
