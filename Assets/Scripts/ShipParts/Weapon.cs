using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dictates how a weapon fires.
public class Weapon : MonoBehaviour {
    public GameObject projectile;
    public float drain { protected set; get; }
    public float cooldown { protected set; get; }

    public float space { protected set; get; }
    public float weight { protected set; get; }
    public float complexity { protected set; get; }

    protected virtual void Awake() {
        drain = 0;
        cooldown = 0;
        space = 0;
        weight = 0;
        complexity = 0;
    }
        
    //Fires a single projectile straight up
    public virtual void fire(float x, float y, float speed) {
        Rigidbody2D clone = Rigidbody2D.Instantiate(projectile.GetComponent<Rigidbody2D>(), new Vector2(x, y), new Quaternion()) as Rigidbody2D;
        clone.velocity = new Vector2(0, speed);
    }
}
