using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    public CreativeSpore.SuperTilemapEditor.Tilemap background;
    public Camera mainCamera;
    private CameraController cameraScript;
    protected float duration;
    protected float scrollSpeed;
    float counter = 0f;


    protected void Awake() {
        cameraScript = mainCamera.gameObject.GetComponent<CameraController>();
        scrollSpeed = 0.5f;
        duration = (background.MapBounds.max.y - background.MapBounds.min.y - mainCamera.orthographicSize) / scrollSpeed * background.transform.localScale.y;
    }
}
