using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {
    public GameManager gamestate;
    public GameObject pe;
    private GameObject tempPe;
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
            tempPe = Instantiate(pe, gameObject.transform.position, gameObject.transform.rotation);
            gamestate.increaseCurrent();
            Destroy(gameObject);
            Destroy(tempPe,3);
            Debug.Log("collided");
        }
    }

}
