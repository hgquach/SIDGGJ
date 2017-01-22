using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour {

    public float timer;
    public float flipflop = 3;
    bool flip = true;

	// Use this for initialization
	void Start () {
		
	}

    void OnEnable()
    {
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (flip)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if(timer > flipflop)
        {
            flip = false;
        }
        if(timer < -flipflop)
        {
            flip = true;
        }

        gameObject.GetComponent<Light>().range = Mathf.Abs(timer) * 2.5f;

    }
}
