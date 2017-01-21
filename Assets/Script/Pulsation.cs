using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsation : MonoBehaviour {
		int speed;
		public Rigidbody2D rb2D; 
		float percentScale;
		bool increase = true;
	// Use this for initialization
	void Start () {
				rb2D = GetComponent<Rigidbody2D>();
				speed = 20;
				percentScale = 1.00f;
	}
	
	// Update is called once per frame
	void Update () {
				rb2D.MoveRotation(rb2D.rotation + speed * Time.fixedDeltaTime);
				rb2D.transform.localScale = new Vector3(percentScale, percentScale, 1);
				if (increase)
				{
						percentScale += .05f;
				}
				else
				{
						percentScale -= .05f;
				}
				if (percentScale >= 1.5f || percentScale <= 0.5f)
				{
						increase = !increase;
				}
	}
}
