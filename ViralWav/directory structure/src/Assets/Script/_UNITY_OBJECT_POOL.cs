using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _UNITY_OBJECT_POOL : MonoBehaviour {

    public static _UNITY_OBJECT_POOL current;
    public GameObject wavePrefab;
    public int pool = 1800;
    public List<GameObject> waveParts;
    public bool willGrow = true;

    void Awake()
    {
        current = this;
    }
    
    void Start () {

        waveParts = new List<GameObject>();

        for(int i = 0; i < pool; i++)
        {
            GameObject obj = (GameObject)Instantiate(wavePrefab);
            obj.SetActive(false);
            waveParts.Add(obj);
        }
	}

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < waveParts.Count; i++)
        {
            if (!waveParts[i].activeInHierarchy)
            {
                return waveParts[i];
            }
        }

        if(willGrow)
        {
            GameObject obj = (GameObject)Instantiate(wavePrefab);
            waveParts.Add(obj);
            return obj;
        }

        return null;
    }
	
}
