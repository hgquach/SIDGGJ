using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour
{
    ParticleSystem particleS; //If we use it.
    float killTime = 0;
    bool dead = false;
    void Start()
    {
        particleS = gameObject.GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) // The Pillar layer
        {
            //Debug.Log("HIT!");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            DestroyObject(gameObject);
        }
    }

    void Update()
    {

    }
}
