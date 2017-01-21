using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//With credit to UnityGems for their implementation online (for Object Pooling)
//Reference: https://unitygem.wordpress.com/object-pooling/

public sealed class _OBJECT_POOL
{
    private static _OBJECT_POOL instance = null;
    public static _OBJECT_POOL Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new _OBJECT_POOL();
            }
            return instance;
        }
    }
    public void Reset()
    {
        instance = null;
    }
    private _OBJECT_POOL() { }

    private Dictionary<string, Queue<GameObject>> container = new Dictionary<string, Queue<GameObject>>();
    private Dictionary<string, GameObject> prefabContainer = new Dictionary<string, GameObject>();

    public bool AddToPool(GameObject prefab, int count, Transform parent = null)
    {
        if (prefab == null || count <= 0) { return false; }
        string name = prefab.name;
        if (this.prefabContainer.ContainsKey(name) == false)
        {
            this.prefabContainer.Add(name, prefab);
        }
        if (this.prefabContainer[name] == null)
        {
            this.prefabContainer[name] = prefab;
        }
        for (int i = 0; i < count; i++)
        {
            GameObject obj = PopFromPool(name, true);
            PushToPool(ref obj, true, parent);
        }
        return true;
    }

    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private Transform bulletContainer = null;
    private void Awake()
    {
        _OBJECT_POOL.Instance.AddToPool(this.bulletPrefab, 20, this.bulletContainer);
    }

    public GameObject PopFromPool(string prefabName, bool forceInstantiate = false,
        bool instantiateIfNone = false, Transform container = null)
    { return null; }
    public GameObject PopFromPool(GameObject prefab, bool forceInstantiate = false,
        bool instantiateIfNone = false, Transform container = null)
    { return null; }
    public void PushToPool(ref GameObject obj, bool retainObject = true,
        Transform parent = null)
    { }
    public void ReleaseItems(GameObject prefab, bool destroyObject = false) { }
    public void ReleasePool() { }
}