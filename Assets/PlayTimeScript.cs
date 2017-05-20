using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTimeScript : MonoBehaviour {

    public float playtime = 0;
    bool runPlayTime = true;
    bool coroutineRunning = false;

    Scene scene;
    int sceneBuildIndex;

    private static GameObject playerInstance;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (playerInstance == null)
        {
            playerInstance = this.gameObject;
        }
        else {
            DestroyObject(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        //scene = SceneManager.GetActiveScene();

        //if(scene.buildIndex == 2 && playtime == 0)
        //{
        //    StartCoroutine(Playtime());
        //}
		
	}

    void Update()
    {
        scene = SceneManager.GetActiveScene();
        sceneBuildIndex = scene.buildIndex;
        //Change to scene of end screen or main menu
        if (sceneBuildIndex == 10 || sceneBuildIndex == 0 )
        {
            runPlayTime = false;
            coroutineRunning = false;
        }

        if (scene.buildIndex == 2 && playtime == 0 && coroutineRunning == false)
        {
            runPlayTime = true;
            StartCoroutine(Playtime());

            coroutineRunning = true;
        }
    }

    private IEnumerator Playtime()
    {
        while (runPlayTime == true)
        {
            yield return new WaitForSeconds(1);
            playtime += 1;
        }
        //set the last player's time
        PlayerPrefs.SetFloat("Current Time", playtime);

        //when coroutine ends saved playtime to playerprefs
        if(PlayerPrefs.GetFloat("Highscore") == 0 )
        {
            PlayerPrefs.SetFloat("Highscore", playtime);
            print("first time highscore set");
        }
        else if (PlayerPrefs.GetFloat("Highscore") > playtime)
        {
            PlayerPrefs.SetFloat("Highscore", playtime);
            print("highscore set");
        }
        playtime = 0;
    }

  
}
