using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    
    public Button exitText;

    // Use this for initialization
    void Start()
    {
       
        exitText = exitText.GetComponent<Button>();

    }

    public void ExitGame()
    {
        // takes you back to main menu
        SceneManager.LoadScene(0);
    }
}
