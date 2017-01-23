using UnityEngine;
using System.Collections;

public class Decay : MonoBehaviour {

	public float lifeDuration;

	private float killTime;

	// Use this for initialization
	void OnEnable() {
		killTime = Time.fixedTime + lifeDuration;
	}
	
	void FixedUpdate () {
		if (killTime <= Time.fixedTime) {
            gameObject.SetActive(false);
        }
	}
}
