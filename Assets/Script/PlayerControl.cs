﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float playerSpeed;
    private float moveX;
    private float moveY;
    private Vector2 movement;
	public float boostSpd;
	public int boostTime;
	public int boostDelay;
	int boosting;
	float boostMoveX;
	float boostMoveY;
	int charges;
	public int maxCharges;
	public int chargeRecharge;
	int charging;

    private Rigidbody2D playerRigidbody; 

    private Animator anim;

	// Use this for initialization
	void Start () {
        playerSpeed = 5f;
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isMoving", false);
        boostSpd = 6f;
        boostTime = 7;
        boostDelay = 5;
        boosting = 0;
		maxCharges = 3;
		charges = maxCharges;
		chargeRecharge = 100;
		charging = 0;
    }

	// Update is called once per frame
	void FixedUpdate () {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX,moveY);

		if (Input.GetButtonDown("Jump") && boosting <= 0 && charges > 0)
		{
			boosting = boostTime + boostDelay;
			boostMoveX = moveX;
			boostMoveY = moveY;
			charges--;
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
		
		if(charging == chargeRecharge && charges < maxCharges)
		{
			charges++;
			charging = 0;
		}
		if (charges < maxCharges)
		{
			charging++;
		}

		Vector2 moveDirection;  
		Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
		moveDirection = rb2d.velocity;
		if (moveDirection != Vector2.zero)
        {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
		}
	}
}
