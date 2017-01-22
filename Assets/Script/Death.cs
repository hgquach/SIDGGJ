using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameOverMenu DeathMenu;
    public TimeManager timeManager;
    private Animator anim;

    private GameObject GM;
    private GameManager gameManager;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        GM = GameObject.FindGameObjectWithTag("gameState");
        gameManager = GM.GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Wave"))
		{
            gameManager.soundTrigger("death");
            // slow mo death
            timeManager.SlowMotion();
            anim.SetBool("isDead", true);
            //activate death menu
            DeathMenu.deathMenu.enabled = true;
		}
	}

    void deleteObj()
    {
        Destroy(gameObject);
    }
}

