using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
		public bool isDying;
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
						
						Destroy(this.gameObject);
				}
		}
}

