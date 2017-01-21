using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpell : MonoBehaviour {

    public GameObject wavePrefab;

    public void fire(float baseDirection, float arcWidthDeg, float waveSizeDeg, float speed)
    {
        float baseAngleRad = Mathf.Deg2Rad * baseDirection;
        float arcWidthRad = Mathf.Deg2Rad * arcWidthDeg;
        float waveSizeRad = Mathf.Deg2Rad * waveSizeDeg;

        List<GameObject> siblings = new List<GameObject>();

        // loop through each shot, from middle out
        // each shot is waveSizeDeg apart
        for (float dAngleRad = 0.0f; dAngleRad <= arcWidthRad / 2; dAngleRad += waveSizeRad)
        {
            float leftAngle = Mathf.Repeat(baseAngleRad - dAngleRad, Mathf.PI * 2);
            float rightAngle = Mathf.Repeat(baseAngleRad + dAngleRad, Mathf.PI * 2);

            // fire to the left
            siblings.Add(fire(leftAngle, speed));
            // fire to the right (don't fire duplicate if dAngle = 0 or 2PI)
            if (Mathf.Abs(Mathf.Repeat(leftAngle - rightAngle, Mathf.PI * 2)) >= waveSizeRad)
            {
                siblings.Add(fire(rightAngle, speed));
            }
        }

        // update sibling list for each "wave",
        // so they know what other "waves" were shot alongside them
        if (wavePrefab.GetComponent<SiblingTracker>() != null)
        {
            foreach (GameObject sibling in siblings)
            {
                sibling.GetComponent<SiblingTracker>().siblings = siblings;
            }
        }
    }

    public GameObject fire(float angleRad, float speed)
    {
        return fire(new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)), speed);
    }

    public GameObject fire(Vector2 direction, float speed)
    {
        GameObject wave;
        //Just in case:
        direction.Normalize();
        if (wavePrefab.name == "Mudball" || wavePrefab.name == "Iceball" || wavePrefab.name == "Lightning" || wavePrefab.name == "Bees")
        {
            wave = (GameObject)Instantiate(wavePrefab, transform.position + new Vector3(direction.x, direction.y, -0.1f), Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x)));
        }
        else
        {
            wave = (GameObject)Instantiate(wavePrefab, transform.position + new Vector3(direction.x, direction.y, -0.1f), Quaternion.identity);
        }

        Rigidbody2D waveRigidBody2D = wave.GetComponent<Rigidbody2D>();
        if (waveRigidBody2D != null)
        {
            waveRigidBody2D.velocity = direction * speed;
        }

        return wave;
    }
}
