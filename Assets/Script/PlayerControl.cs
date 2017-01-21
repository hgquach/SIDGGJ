using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float playerSpeed;
<<<<<<< HEAD
    private float moveX;
    private float moveY;
    private Vector2 movement;
=======
    public float moveX;
    public float moveY;
	public float boostSpd;
		public int boostTime;
		public int boostDelay;
		int boosting;
		float boostMoveX;
		float boostMoveY;


    private Rigidbody2D playerRigidbody; 
>>>>>>> origin/master

    private Rigidbody2D playerRigidbody;
    private Animator anim;
	// Use this for initialization
	void Start () {
        playerSpeed = 10f;
        playerRigidbody = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        anim = GetComponent<Animator>();
        anim.SetBool("isMoving", false);



    }

    // Update is called once per frame
    void FixedUpdate () {
=======
		boostSpd = 3f;
				boostTime = 7;
				boostDelay = 5;
				boosting = 0;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
>>>>>>> origin/master

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX,moveY);

<<<<<<< HEAD
        playerRigidbody.velocity = new Vector2(moveX * playerSpeed, moveY * playerSpeed);
		if(playerRigidbody.velocity == Vector2.zero)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("moveX", movement.x);
            anim.SetFloat("lastMoveX", movement.x);
            anim.SetFloat("moveY", movement.y);
            anim.SetFloat("lastMoveY", movement.y);

        }
    }
=======
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
>>>>>>> origin/master
}
