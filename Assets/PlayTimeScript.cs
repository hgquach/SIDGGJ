using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTimeScript : MonoBehaviour {

    public float playtime = 0;
    bool runPlayTime = true;

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
        scene = SceneManager.GetActiveScene();
		StartCoroutine(Playtime());
	}

    void Update()
    {
        scene = SceneManager.GetActiveScene();
        sceneBuildIndex = scene.buildIndex;
        //Change to scene of end screen
        if (sceneBuildIndex == 10)
        {
            runPlayTime = false;
            
        }
    }

    private IEnumerator Playtime()
    {
        while (runPlayTime == true)
        {
            yield return new WaitForSeconds(1);
            playtime += 1;
        }
        //when coroutine ends saved playtime to playerprefs
        PlayerPrefs.SetFloat("Highscore", playtime);
        print("highscore set");
    }

  
}
