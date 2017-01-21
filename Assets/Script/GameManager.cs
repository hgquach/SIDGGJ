using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int numOfTotalCollect = 0;
    public int numOfCurrentCollect = 0; 
	// Use this for initialization
	void Start () {
         	
	}
	
	// Update is called once  per frame
	void Update () {

        if(numOfCurrentCollect == numOfTotalCollect)
        {
            print("Game Ended");
        }

        print(numOfCurrentCollect);
		
	}

    public void increaseCurrent()
    {
        ++numOfCurrentCollect;
    }
}
