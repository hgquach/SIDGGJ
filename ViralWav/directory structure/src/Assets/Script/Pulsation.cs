using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsation : MonoBehaviour {
		int speed;
		public Rigidbody2D rb2D; 
		float percentScale;
		bool increase = true;
		Quaternion rotato;
	// Use this for initialization
	void Start () {
				rb2D = GetComponent<Rigidbody2D>();
				speed = 45;
				percentScale = 1.00f;
				rotato = rb2D.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
				//rb2D.transform.localRotation = Quaternion.Euler(new Vector3(speed, ))
				rb2D.transform.Rotate(0, 0, Time.deltaTime * speed);
				rb2D.transform.localScale = new Vector3(percentScale, percentScale, 1);
				if (increase)
				{
						percentScale += .025f;
				}
				else
				{
						percentScale -= .025f;
				}
				if (percentScale >= 1.5f || percentScale <= 0.5f)
				{
						increase = !increase;
				}
	}
}
