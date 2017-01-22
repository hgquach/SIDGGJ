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
    public int totalScore;

    //cache
    private AudioManager audioManager;

    // Audio
    public string BGM;
    public string collectSound;
    public string dashSound;

	// Use this for initialization
	void Start () {
				exit = GameObject.FindWithTag("Finish");
				exit.SetActive(false);
        CollectLeft = numOfTotalCollect;
        scoreText.text = "Bugs Left: " + CollectLeft;

        //caching
        audioManager = AudioManager.instance;
        if(audioManager == null)
        {
            Debug.LogError("No AudioManager found in the scene");
        }
        audioManager.PlaySound(BGM);
        
    }
	
	// Update is called once  per frame
	void Update () {

        if(numOfCurrentCollect == numOfTotalCollect)
        {
						exit.SetActive(true);
        }

        //print(numOfCurrentCollect);
		
	}

    public void increaseCurrent()
    {
        ++numOfCurrentCollect;
        --CollectLeft;
        totalScore += 1;
        audioManager.PlaySound(collectSound);
        scoreText.text = "Bugs Left: " + CollectLeft;
    }

    public void soundTrigger(string _name)
    {
        if(_name == "dash")
        {
            audioManager.PlaySound(dashSound);
        }
        
    }
}
