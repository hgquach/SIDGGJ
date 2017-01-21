using UnityEngine;
using System.Collections;

// Utilizes code from Team Silly-String of Josh Tanenbaum's ICS 169 Capstone Game Project class.
// With regards to: Cory Sherman; Nathan Krueger; Winston Liang; Tom Tan; Lucas Amutan (who is using the spell code!)

public class TrapShot : MonoBehaviour {

    public GameObject wavePrefab;
    public WaveSpell trap;
    public Vector2 baseDirection;
    public float arcWidthDeg;
    public float spellSizeDeg;
    public float speed;

    public float timer = 0;
    public float timeLimit;

    // Use this for initialization
    void Start () {
        trap = GetComponent<WaveSpell>();
        trap.wavePrefab = wavePrefab;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= timeLimit)
        {
            float spellSizeDegUse = spellSizeDeg;
            if (trap.wavePrefab.name == "QuickRock")
            {
                spellSizeDegUse = arcWidthDeg / 2;
            }
            trap.fire(baseDirection, arcWidthDeg, spellSizeDegUse, speed);
            timer = 0;
        }
	}
}
