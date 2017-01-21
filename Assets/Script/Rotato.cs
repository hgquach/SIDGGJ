using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotato : MonoBehaviour {

    public WaveShot waveShot;
    public float degreeChange; //How much do we rotate?
    public float duration; //How much time between rotations?

    public bool flip; //Do we flip flop?
    public float flipLimMin; //If we do, when? -- based off the initial start of the waveShot.
    public float flipLimMax;

    public float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= duration)
        {
            waveShot.baseDirection += degreeChange;
            if(waveShot.baseDirection >= 360)
            {
                waveShot.baseDirection -= 360;
            }
            timer = 0;

            if(flip)
            {
                if (waveShot.baseDirection >= flipLimMax || waveShot.baseDirection <= flipLimMin)
                {
                    degreeChange *= -1;
                }
            }
        }
	}
}
