using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour {

    float timer;
    float flipflop;

	// Use this for initialization
	void Start () {
		
	}

    void OnEnable()
    {
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > Mathf.Abs(flipflop) || timer < Mathf.Abs(flipflop))
        {
            gameObject.GetComponent<Light>().range = timer * 3;
        }
	}
}
