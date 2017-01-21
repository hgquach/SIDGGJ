using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float playerSpeed;
    public float moveX;
    public float moveY;

    private Rigidbody2D playerRigidbody; 

	// Use this for initialization
	void Start () {
        playerSpeed = 10f;
        playerRigidbody = GetComponent<Rigidbody2D>();

        
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveX,moveY);

        playerRigidbody.velocity = new Vector2(moveX * playerSpeed, moveY * playerSpeed);
		
	}
}
