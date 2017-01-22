using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulsate : MonoBehaviour {
		Transform T;

		private const float PULSE_RANGE = 4.0f;
		private const float PULSE_SPEED = 3.0f;

		private const float PULSE_MINIMUM = 1.0f;
	// Use this for initialization
	void Start () {
				T = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

				currentSpellLight.range = PULSE_MINIMUM +
						Mathf.PingPong(Time.time * PULSE_SPEED, 
								PULSE_RANGE - PULSE_MINIMUM);
	}

		void OnEnable()
		{
				
		}
}
