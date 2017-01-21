using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float playerSpeed;
    public float moveX;
    public float moveY;
	public float boostSpd;
		public int boostTime;
		public int boostDelay;
		int boosting;
		float boostMoveX;
		float boostMoveY;


    private Rigidbody2D playerRigidbody; 

	// Use this for initialization
	void Start () {
        playerSpeed = 10f;
        playerRigidbody = GetComponent<Rigidbody2D>();
		boostSpd = 3f;
				boostTime = 7;
				boostDelay = 5;
				boosting = 0;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveX,moveY);

				if (Input.GetKeyDown(KeyCode.Space) && boosting <= 0)
				{
						boosting = boostTime + boostDelay;
						boostMoveX = moveX;
						boostMoveY = moveY;
				}
		
				if (boosting <= 0)
				{
						playerRigidbody.velocity = new Vector2(moveX * playerSpeed, moveY * playerSpeed);
				}
				else if (boosting > boostTime)
				{
						playerRigidbody.velocity = new Vector2(0, 0);
						boosting--;
				}
				else
				{
						playerRigidbody.velocity = new Vector2(boostMoveX * playerSpeed * boostSpd, boostMoveY * playerSpeed * boostSpd);
						boosting--;
				}
        
		
	}
}
