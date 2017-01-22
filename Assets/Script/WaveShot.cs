using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveShot : MonoBehaviour {

    public GameObject wavePrefab;
    public WaveSpell wave;
    public Light underglow;

    public float baseDirection;
    public float arcWidthDeg;
    public float waveSizeDeg;
    public float speed;

    public string colorsToSep; //What colors of wave are we firing?
    public string[] colors;

    public float timer = 0;
    public float timeLimit;
    public float decayTime; //When will the wave "decay" (due to time)

    public int counter;
    private int oneAhead; //The predictor for the next colour of the wave.

    public bool resonates = false; //Is this a resonater Generator?

    // Use this for initialization
    void Start () {

        counter = 0;
        oneAhead = 1;

        //Debug.Log(colorsToSep);
        if(colorsToSep.Length > 0)
        {
            colors = colorsToSep.Split(","[0]);
            if (colors[counter] == "w")
            {
                underglow.color = Color.white;
            }
            if (colors[counter] == "r")
            {
                underglow.color = Color.red;
            }
            if (colors[counter] == "g")
            {
                underglow.color = Color.green;
            }
            if (colors[counter] == "b")
            {
                underglow.color = Color.blue;
            }
            if (colors[counter] == "y")
            {
                underglow.color = Color.yellow;
            }
        }
        //Debug.Log(colors);
    }
	
    public void resonate()
    {
        if (timer >= timeLimit)
        {
            wave.fire(baseDirection, arcWidthDeg, waveSizeDeg, speed, colors[counter], decayTime);
            timer = 0;
        }
    }

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (!resonates)
        {
            float percent = timer / timeLimit;
            underglow.range = 4 * percent;
        }
        else
        {
            underglow.range = 3;
        }

        if(timer >= timeLimit && !resonates)
        {
            if (colors.Length > 1) // Changes the color of the light under the Generator, so you can predict what's coming up!
                {
                    if (colors[oneAhead] == "w")
                    {
                        underglow.color = Color.white;
                    }
                    if (colors[oneAhead] == "r")
                    {
                        underglow.color = Color.red;
                    }
                    if (colors[oneAhead] == "g")
                    {
                        underglow.color = Color.green;
                    }
                    if (colors[oneAhead] == "b")
                    {
                        underglow.color = Color.blue;
                    }
                    if (colors[oneAhead] == "y")
                    {
                        underglow.color = Color.yellow;
                    }
                }
            else
                {
                    underglow.color = Color.white;
                }

            wave.fire(baseDirection, arcWidthDeg, waveSizeDeg, speed, colors[counter], decayTime);
            
            timer = 0;

            underglow.range = 0;
            
            counter += 1;
            oneAhead += 1;
            if (counter >= colors.Length)
                {
                    counter = 0;
                }
            if (oneAhead >= colors.Length)
                {
                    oneAhead = 0;
                }
        }
	}
}
