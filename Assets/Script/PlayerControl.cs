using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private float moveX;
    private float moveY;
    private Vector2 movement;
    private TrailRenderer tr;
    private Rigidbody2D playerRigidbody;
    private Animator anim;
    private float boostMoveX;
    private float boostMoveY;
    private int charging;


    public float boostSpd;
	public int boostTime;
	public int boostDelay;
    public float playerSpeed;
    public int boosting;
	public int charges;
	public int maxCharges;
	public int chargeRecharge;


	// Use this for initialization
	void Start () {
        playerSpeed = 5f;
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
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
    void Update()
    {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);

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


        if (playerRigidbody.velocity == Vector2.zero)
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

        if (charging == chargeRecharge && charges < maxCharges)
        {
            charges++;
            charging = 0;
        }
        if (charges < maxCharges)
        {
            charging++;
        }

        // pasta code 
        Vector2 moveDirection;
        Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
        moveDirection = rb2d.velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    
    // code to change the trail color depedning on the charge left 
    float alpha = 1.0f;
        Gradient gradient = new Gradient();
        switch (charges)
        {
            case 0:
                gradient.SetKeys(
                    new GradientColorKey[] {new GradientColorKey(Color.white, 0.0f),
                    new GradientColorKey(Color.white, 39.4f),new GradientColorKey(Color.white, 95.6f)},
                    new GradientAlphaKey[] {new GradientAlphaKey(alpha,0.0f), new GradientAlphaKey(alpha,48.5f),
                    new GradientAlphaKey(169,98.5f) });
                tr.colorGradient = gradient;
                break;
            case 1:
                gradient.SetKeys(
                    new GradientColorKey[] {new GradientColorKey(new Color(137,0,0), 0.0f),
                    new GradientColorKey(new Color(240,56,56), 39.4f),new GradientColorKey(new Color(255,184,184), 95.6f)},
                    new GradientAlphaKey[] {new GradientAlphaKey(alpha,0.0f), new GradientAlphaKey(alpha,48.5f),
                    new GradientAlphaKey(169,98.5f) });
                tr.colorGradient = gradient;
                break;
            case 2:
                gradient.SetKeys(
                    new GradientColorKey[] {new GradientColorKey(new Color(246,229,0), 0.0f),
                    new GradientColorKey(new Color(248,243,102), 39.4f),new GradientColorKey(new Color(240,251,207), 95.6f)},
                    new GradientAlphaKey[] {new GradientAlphaKey(alpha,0.0f), new GradientAlphaKey(alpha,48.5f),
                    new GradientAlphaKey(169,98.5f) });
                tr.colorGradient = gradient;
                break;
            case 3:
                gradient.SetKeys(
                    new GradientColorKey[] {new GradientColorKey(new Color(11,100,8), 0.0f),
                    new GradientColorKey(new Color(24,182,0), 39.4f),new GradientColorKey(new Color(55,255,22), 95.6f)},
                    new GradientAlphaKey[] {new GradientAlphaKey(alpha,0.0f), new GradientAlphaKey(alpha,48.5f),
                    new GradientAlphaKey(169,98.5f) });
                tr.colorGradient = gradient;
                break;

        }
    }
        // Update is called once per frame


}
