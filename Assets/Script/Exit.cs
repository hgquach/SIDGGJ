﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    public int nextLevel = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

		void OnTriggerEnter2D(Collider2D other)
		{
            if(other.tag == "Player")
            {
                Debug.Log("Enter Next Level");
                SceneManager.LoadScene(nextLevel);
            }
				
        }
}
