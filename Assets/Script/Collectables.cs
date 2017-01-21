using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {
    public GameManager gamestate;
	// Use this for initialization
	void Start () {
        gamestate = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gamestate.increaseCurrent();

            Destroy(gameObject);
            Debug.Log("collided");
        }
    }
}
