using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public Canvas deathMenu;
    public Text scoreText;
    public Button retryText;
    public Button quitText;
    public int retryScene = 2;
    public int totalScore;

    public TimeManager afterDeath;

    public GameManager gameManager;

    // Use this for initialization
    void Start () {
        deathMenu = deathMenu.GetComponent<Canvas>();
        retryText = retryText.GetComponent<Button>();
        quitText = quitText.GetComponent<Button>();
        gameManager = gameManager.GetComponent<GameManager>();

        deathMenu.enabled = false;

        
    }

    void Update()
    {
        totalScore = gameManager.totalScore;
        scoreText.text = "Score: " + totalScore.ToString();
    }
	
	

    public void RetryLevel()
    {
        SceneManager.LoadScene(retryScene);
        deathMenu.enabled = false;
        gameManager.totalScore = 0;
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
