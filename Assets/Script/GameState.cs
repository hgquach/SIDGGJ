using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public int numOfTotalCollect;
    public int numOfCurrentCollect; 
	// Use this for initialization
	void Start () {
        numOfTotalCollect = 3;
        numOfCurrentCollect = 0; 
		
	}
	
	// Update is called once  per frame
	void Update () {

        if(numOfCurrentCollect == numOfTotalCollect)
        {
            print("Game Ended")
        }
		
	}
}
