using UnityEngine;
using System.Collections.Generic;

/// Simple pooling for Unity.
///   Author: Martin "quill18" Glaude (quill18@quill18.com)
///   Latest Version: https://gist.github.com/quill18/5a7cfffae68892621267
///   License: CC0 (http://creativecommons.org/publicdomain/zero/1.0/)
///   UPDATES:
/// 	2015-04-16: Changed Pool to use a Stack generic.
/// 
/// Usage:
/// 
///   There's no need to do any special setup of any kind.
/// 
///   Instead of calling Instantiate(), use this:
///       SimplePool.Spawn(somePrefab, somePosition, someRotation);
/// 
///   Instead of destroying an object, use this:
///       SimplePool.Despawn(myGameObject);
/// 
///   If desired, you can preload the pool with a number of instances:
///       SimplePool.Preload(somePrefab, 20);
/// 
/// Remember that Awake and Start will only ever be called on the first instantiation
/// and that member variables won't be reset automatically.  You should reset your
/// object yourself after calling Spawn().  (i.e. You'll have to do things like set
/// the object's HPs to max, reset animation states, etc...) OnEnable will run
/// after spawning -- but remember that toggling IsActive will also call that function.


//Taken from https://gist.github.com/quill18/5a7cfffae68892621267

public static class SimplePool {
    // Note, you can also use Preload() to set the initial size
    // of a pool -- this can be handy if only some of your pools
    // are going to be exceptionally large (for example, your bullets.)
    const int DEFAULT_POOL_SIZE = 3;

    class Pool {
        int nextId = 1;
        Stack<GameObject> inactive;

        // The prefab that we are pooling
        GameObject prefab;

        //Constructor
        public Pool(GameObject prefab, int initialQty) {
            this.prefab = prefab;
            inactive = new Stack<GameObject>(initialQty);
        }

        // Spawn an object from our pool
        public GameObject Spawn(Vector3 pos, Quaternion rot) {
            GameObject obj;
            if (inactive.Count == 0) {
                // Pool is empty, so instantiate a new object
                obj = (GameObject)GameObject.Instantiate(prefab, pos, rot);
                obj.name = prefab.name + " (" + (nextId++) + ")";

                // Add a PoolMember component to indicate which pool that object belongs to
                obj.AddComponent<PoolMember>().myPool = this;
            }
            else {
                // Grab the last object in the inactive array
                obj = inactive.Pop();

                if (obj == null) {
                    return Spawn(pos, rot);
                }
            }

            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.SetActive(true);
            return obj;
        }

        // Return an object to the inactive pool.
        public void Despawn(GameObject obj) {
            obj.SetActive(false);
            inactive.Push(obj);
        }

    }


    // Added to freshly instantiated objects so we can link back to the correct pool on despawn.
    class PoolMember : MonoBehaviour {
        public Pool myPool;
    }

    // All of our pools
    static Dictionary<GameObject, Pool> pools;


    /// Initialize our dictionary.
    static void Init(GameObject prefab = null, int qty = DEFAULT_POOL_SIZE) {
        if (pools == null) {
            pools = new Dictionary<GameObject, Pool>();
        }
        if (prefab != null && pools.ContainsKey(prefab) == false) {
            pools[prefab] = new Pool(prefab, qty);
        }
    }

    /// <summary>
    /// Can be used if you want to preload a few copies of an object at the start
    /// of a scene, but in practice Spawn/Despawn is good enough unless you need to
    /// go from 0 to 100+ objects very quickly.
    /// </summary>
    static public void Preload(GameObject prefab, int qty = 1) {
        Init(prefab, qty);

        // Make an array to grab the objects we're about to pre-spawn.
        GameObject[] obs = new GameObject[qty];
        for (int i = 0; i < qty; i++) {
            obs[i] = Spawn(prefab, Vector3.zero, Quaternion.identity);
        }

        // Now despawn them all.
        for (int i = 0; i < qty; i++) {
            Despawn(obs[i]);
        }
    }


    // Spawns a copy of the specified prefab (instantiating one if required).
    static public GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot) {
        Init(prefab);

        return pools[prefab].Spawn(pos, rot);
    }


    // Despawn the specified gameobject back into its pool.
    static public void Despawn(GameObject obj) {
        PoolMember pm = obj.GetComponent<PoolMember>();
        if (pm == null) {
            Debug.Log("Object '" + obj.name + "' wasn't spawned from a pool. Destroying it instead.");
            GameObject.Destroy(obj);
        }
        else {
            pm.myPool.Despawn(obj);
        }
    }
}