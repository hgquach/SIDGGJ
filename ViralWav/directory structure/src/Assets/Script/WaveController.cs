﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveController : MonoBehaviour
{
    //ParticleSystem particleS; //If we use it.
    float killTime = 0;
    bool dead = false;

    public string color;
    public string goesThrough;

    public float speed;
    public Vector2 direction;

    void OnEnable()
    {
        //particleS = gameObject.GetComponent<ParticleSystem>();
        if (color != "w")
        {
            if(color == "r")
            {
                goesThrough = "RedObstacle";
                gameObject.GetComponent<Light>().color = Color.red; 
            }
            if (color == "g")
            {
                goesThrough = "GreenObstacle";
                gameObject.GetComponent<Light>().color = Color.green;
            }
            if (color == "b")
            {
                goesThrough = "BlueObstacle";
                gameObject.GetComponent<Light>().color = Color.blue;
            }
            if (color == "y")
            {
                goesThrough = "YellowObstacle";
                gameObject.GetComponent<Light>().color = Color.yellow;
            }
        }
        else
        {
            goesThrough = "ALL";
            gameObject.GetComponent<Light>().color = Color.white;
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Resonator") && goesThrough != "ALL")
        {
            collision.GetComponent<WaveShot>().resonate();

            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.SetActive(false);
        }
        if (collision.gameObject.layer == 9) // The Wall layer
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.SetActive(false);
        }

        if (collision.gameObject.layer == 8) // The Pillar layer
        {
            if (goesThrough == "ALL")
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                gameObject.SetActive(false);
            }
            else
            {
                if (!collision.gameObject.CompareTag(goesThrough))
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }

    void Update()
    {

    }
}
