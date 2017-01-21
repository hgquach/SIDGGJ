using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveShot : MonoBehaviour {

    public GameObject wavePrefab;
    public WaveSpell wave;

    public float baseDirection;
    public float arcWidthDeg;
    public float waveSizeDeg;
    public float speed;

    public string colorsToSep;
    public string[] colors;

    public float timer = 0;
    public float timeLimit;
    public float decayTime;

    public int counter;

    // Use this for initialization
    void Start () {

        wavePrefab.GetComponent<Decay>().lifeDuration = decayTime;

        wave = GetComponent<WaveSpell>();
        wave.wavePrefab = wavePrefab;

        counter = 0;

        //Debug.Log(colorsToSep);
        if(colorsToSep.Length > 0)
        {
            colors = colorsToSep.Split(","[0]);
        }
        //Debug.Log(colors);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= timeLimit)
        {
            //Debug.Log(colors[counter]); This will be how we figure out what sort of "wave" the item is.
            counter += 1;
            if (counter >= colors.Length)
            {
                counter = 0;
            }

            wave.wavePrefab.GetComponent<WaveController>().color = colors[counter];

            float waveSizeDegUse = waveSizeDeg;
            wave.fire(baseDirection, arcWidthDeg, waveSizeDegUse, speed);
            timer = 0;
        }
	}
}
