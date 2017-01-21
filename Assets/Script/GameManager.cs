using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int numOfTotalCollect = 0;
    public int numOfCurrentCollect = 0; 
	public GameObject exit;

    public Text scoreText;
    private int CollectLeft;

	// Use this for initialization
	void Start () {
				exit = GameObject.FindWithTag("Finish");
				exit.SetActive(false);
        CollectLeft = numOfTotalCollect;
        scoreText.text = "Bugs Left: " + CollectLeft;
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
        --CollectLeft;
        scoreText.text = "Bugs Left: " + CollectLeft;
    }
}
