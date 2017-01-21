using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public Canvas deathMenu;
    public Button retryText;
    public Button quitText;

    // Use this for initialization
    void Start () {
        deathMenu = deathMenu.GetComponent<Canvas>();
        retryText = retryText.GetComponent<Button>();
        quitText = quitText.GetComponent<Button>();

        deathMenu.enabled = false;
    }
	
	

    public void RetryLevel()
    {
        SceneManager.LoadScene(2);
        deathMenu.enabled = false;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
