using UnityEngine;
using System.Collections;

// Utilizes code from Team Silly-String of Josh Tanenbaum's ICS 169 Capstone Game Project class.
// With regards to: Cory Sherman; Nathan Krueger; Winston Liang; Tom Tan; Lucas Amutan (who is using the spell code!)

public class WaveController : MonoBehaviour
{
    ParticleSystem particleS;
    float killTime = 0;
    bool dead = false;
    void Start()
    {
        particleS = gameObject.GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) // The Pillar layer
        {
            var em = particleS.emission;
            var rate = em.rate;
            rate.constant = 0;
            em.rate = rate;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            dead = true;
        }
    }

    void Update()
    {
        if (dead)
        {
            killTime += Time.deltaTime;
            if (killTime >= 1)
                DestroyObject(gameObject);
        }
    }
}
