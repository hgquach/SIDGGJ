using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public Button startText;
    public Button exitText;
    public Button resetText;

    // Use this for initialization
    void Start()
    {
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        resetText = resetText.GetComponent<Button>();

}

    public void ExitPress()
    {
        startText.enabled = false;
        exitText.enabled = false;
        resetText.enabled = false;
    }

    public void NoPress()
    {
        startText.enabled = true;
        exitText.enabled = true;
        resetText.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(2);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
