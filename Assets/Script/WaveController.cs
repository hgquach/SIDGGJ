using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveController : MonoBehaviour
{
    ParticleSystem particleS; //If we use it.
    float killTime = 0;
    bool dead = false;

    public string color;
    public string goesThrough;

    void Start()
    {
        particleS = gameObject.GetComponent<ParticleSystem>();
        if(color != "w")
        {
            if(color == "r")
            {
                goesThrough = "RedObstacle";
            }
            if (color == "g")
            {
                goesThrough = "GreenObstacle";
            }
            if (color == "b")
            {
                goesThrough = "BlueObstacle";
            }
            if (color == "y")
            {
                goesThrough = "YellowObstacle";
            }
        }
        else
        {
            goesThrough = "ALL";
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) // The Wall layer
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            DestroyObject(gameObject);
        }

        if (collision.gameObject.layer == 8) // The Pillar layer
        {
            if (goesThrough == "ALL")
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                DestroyObject(gameObject);
            }
            else
            {
                if (!collision.gameObject.CompareTag(goesThrough))
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    DestroyObject(gameObject);
                }
            }
        }
    }

    void Update()
    {

    }
}
