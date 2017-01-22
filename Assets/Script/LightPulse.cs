using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour {

    public Exit myExit;
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
            myExit.GetComponent<Light>().range = timer;
        }
	}
}
