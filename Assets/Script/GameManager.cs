using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int numOfTotalCollect = 0;
    public int numOfCurrentCollect = 0; 
	public GameObject exit;
	// Use this for initialization
	void Start () {
				exit = GameObject.FindWithTag("Finish");
				exit.SetActive(false);
	}
	
	// Update is called once  per frame
	void Update () {

        if(numOfCurrentCollect == numOfTotalCollect)
        {
						exit.SetActive(true);
        }

        print(numOfCurrentCollect);
		
	}

    public void increaseCurrent()
    {
        ++numOfCurrentCollect;
    }
}
