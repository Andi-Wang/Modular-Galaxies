using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    public Rigidbody2D projectile;
    protected HashSet<string> validTargets;
    protected float lifespan;
    protected float damage;

	// Use this for initialization
	protected void Awake() {
        setValidTargets();
        setLifespan();
    }

    protected void OnEnable() {
        //Causes the projectile to deal damage even if it was spawned inside of an enemy
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = true;

        //Automatically despawns the projectile after it has existed for its full lifespan
        StartCoroutine(automaticDespawn());
    }

    
    IEnumerator automaticDespawn() {
        yield return new WaitForSeconds(lifespan);
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

    protected virtual void setLifespan () {
        lifespan = 2.5f;
    }
    public void setDamage(float amount) {
        damage = amount;
    }
}
