using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    
    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    private void OnBecameInvisible() {
        SimplePool.Despawn(gameObject);
    }


    protected virtual void FixedUpdate() {
        if(spriteRenderer.isVisible) {
            move();




        }
    }

    protected virtual void move() {
        Debug.Log("Enemy is moving!");
    }

    protected virtual void fire() {
        Debug.Log("Enemy is firing!");
    }

}
