using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {
    public GameManager gamestate;
    public GameObject pe;
    private GameObject tempPe;
    private Animator anim;
    // Use this for initialization
	void Start () {
        gamestate = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Player" && !anim.GetBool("isCollected"))
        {
            tempPe = Instantiate(pe, gameObject.transform.position, gameObject.transform.rotation);
            gamestate.increaseCurrent();
            anim.SetBool("isCollected",true);
            Destroy(gameObject,2);
            Destroy(tempPe,3);
            Debug.Log("collided");
        }
    }

}
