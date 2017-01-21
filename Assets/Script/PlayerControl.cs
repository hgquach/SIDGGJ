using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float playerSpeed;
    private float moveX;
    private float moveY;
    private Vector2 movement;

    private Rigidbody2D playerRigidbody;
    private Animator anim;
	// Use this for initialization
	void Start () {
        playerSpeed = 10f;
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isMoving", false);



    }

    // Update is called once per frame
    void FixedUpdate () {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX,moveY);

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
}
