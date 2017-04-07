using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UtilityModule : MonoBehaviour {
    public float space { protected set; get; }
    public float weight { protected set; get; }
    public float complexity { protected set; get; }

    protected virtual void Awake() {
        space = 0;
        weight = 0;
        complexity = 0;
    }

    public abstract void active();
}
