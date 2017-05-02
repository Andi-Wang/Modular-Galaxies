using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    public Rigidbody2D projectile;
    protected HashSet<string> validTargets;
    protected float damage;

	// Use this for initialization
	protected void Awake() {
        setValidTargets();
    }

    //Automatically despawns the projectile when it moves offscreen
    protected void OnBecameInvisible() {
        SimplePool.Despawn(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D other) {
        string tag = other.gameObject.tag;
        if(validTargets.Contains(tag)) {
            if (tag.Equals("Enemy")) {
                enemyHit();
            }
            else if (tag.Equals("Impassable")) {
                impassableHit();
            }
            else if(tag.Equals("Player")) {
                playerHit();
            }
            else if(tag.Equals("PlayerWeapon")) {
                playerWeaponHit();
            }
            else if(tag.Equals("PlayerSpecial")) {
                playerSpecialHit();
            }
            else if(tag.Equals("EnemyProjectile")) {
                enemyProjectileHit();
            }
        }
    }

    protected virtual void setValidTargets() {
        validTargets = new HashSet<string>();
        validTargets.Add("Enemy");
        validTargets.Add("Impassable");
    }
    protected virtual void enemyHit() {
        SimplePool.Despawn(gameObject);
    }
    protected virtual void impassableHit() {
        SimplePool.Despawn(gameObject);
    }
    protected virtual void playerHit() {

    }
    protected virtual void playerWeaponHit() {

    }
    protected virtual void playerSpecialHit() {

    }
    protected virtual void enemyProjectileHit() {

    }
    public void setDamage(float amount) {
        damage = amount;
    }
}
