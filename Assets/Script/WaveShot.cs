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

    // Use this for initialization
    void Start () {

        wavePrefab.GetComponent<Decay>().lifeDuration = decayTime;

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
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        float percent = timer / timeLimit;
        underglow.range = 4 * percent; 

        if(timer >= timeLimit)
        {
            if (colors.Length != 0) // Changes the color of the light under the Generator, so you can predict what's coming up!
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

            int totalShots = (int)(arcWidthDeg / waveSizeDeg);

            //The math should be -- you're firing a certain amount of shots, every waveSizeDeg.
            //So, 360 at 1 = 360 shots. Right...?
            //Dunno why it spreads out more at 720/2, 1080/3, or 1440/4...

            for (int i = 0; i < totalShots; i += (int)waveSizeDeg)
            {
                wave.fire(baseDirection, arcWidthDeg, i, speed, colors[counter]);
            }
            
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
