using UnityEngine;
using System.Collections;

public class WaveShot : MonoBehaviour {

    public GameObject wavePrefab;
    public WaveSpell wave;
    public float baseDirection;
    public float arcWidthDeg;
    public float waveSizeDeg;
    public float speed;

    public float timer = 0;
    public float timeLimit;

    // Use this for initialization
    void Start () {
        wave = GetComponent<WaveSpell>();
        wave.wavePrefab = wavePrefab;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= timeLimit)
        {
            float waveSizeDegUse = waveSizeDeg;
            wave.fire(baseDirection, arcWidthDeg, waveSizeDegUse, speed);
            timer = 0;
        }
	}
}
