using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsation : MonoBehaviour {
		int speed;
		public Rigidbody2D rb2D; 
	// Use this for initialization
	void Start () {
				rb2D = GetComponent<Rigidbody2D>();
				speed = 2;
	}
	
	// Update is called once per frame
	void Update () {
				rb2d.MoveRotation(rb2D.rotation + speed * Time.fixedDeltaTime);
	}
}
