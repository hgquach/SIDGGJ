using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    
    public Button exitText;
    public Text yourTimeText;
    public Text highscoreText;

    // Use this for initialization
    void Start()
    {
       
        exitText = exitText.GetComponent<Button>();

        yourTimeText.text = "Your Time: " + PlayerPrefs.GetFloat("Current Time").ToString();
        highscoreText.text = "Best Time: " + PlayerPrefs.GetFloat("Highscore").ToString();
    }

    public void ExitGame()
    {
        // takes you back to main menu
        SceneManager.LoadScene(0);
    }
}
