using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
		public bool isDying;

        public GameOverMenu DeathMenu;

    public TimeManager timeManager;

	// Use this for initialization
	void Start () {
				isDying = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (isDying)
				{
            

			Destroy(gameObject);
		}
	}

		void OnTriggerEnter2D(Collider2D other)
		{
				if (other.gameObject.CompareTag("Wave"))
				{
                        // slow mo death
                        timeManager.SlowMotion();

                        Destroy(this.gameObject);
                        //activate death menu
                        DeathMenu.deathMenu.enabled = true;
				}
		}
}

