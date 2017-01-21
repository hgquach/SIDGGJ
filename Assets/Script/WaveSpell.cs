using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Utilizes code from Team Silly-String of Josh Tanenbaum's ICS 169 Capstone Game Project class.
// With regards to: Cory Sherman; Nathan Krueger; Winston Liang; Tom Tan; Lucas Amutan (who is using the spell code!)

public class WaveSpell : MonoBehaviour {

    public GameObject wavePrefab;

    public void fire(Vector2 baseDirection, float arcWidthDeg, float spellSizeDeg, float speed)
    {
        float baseAngleRad = Mathf.Atan2(baseDirection.y, baseDirection.x);
        float arcWidthRad = Mathf.Deg2Rad * arcWidthDeg;
        float spellSizeRad = Mathf.Deg2Rad * spellSizeDeg;

        List<GameObject> siblings = new List<GameObject>();

        // loop through each shot, from middle out
        // each shot is spellSizeDeg apart
        for (float dAngleRad = 0.0f; dAngleRad <= arcWidthRad / 2; dAngleRad += spellSizeRad)
        {
            float leftAngle = Mathf.Repeat(baseAngleRad - dAngleRad, Mathf.PI * 2);
            float rightAngle = Mathf.Repeat(baseAngleRad + dAngleRad, Mathf.PI * 2);

            // fire spell to the left
            siblings.Add(fire(leftAngle, speed));
            // fire spell to the right (don't fire duplicate if dAngle = 0 or 2PI
            if (Mathf.Abs(Mathf.Repeat(leftAngle - rightAngle, Mathf.PI * 2)) >= spellSizeRad)
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

    //This is code from the old "spell" script; kept in in case there is a problem.

    public GameObject fire(Vector2 direction, float speed)
    {
        GameObject spell;
        //Just in case:
        direction.Normalize();
        if (wavePrefab.name == "Mudball" || wavePrefab.name == "Iceball" || wavePrefab.name == "Lightning" || wavePrefab.name == "Bees")
        {
            spell = (GameObject)Instantiate(wavePrefab, transform.position + new Vector3(direction.x, direction.y, -0.1f), Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x)));
        }
        else
        {
            spell = (GameObject)Instantiate(wavePrefab, transform.position + new Vector3(direction.x, direction.y, -0.1f), Quaternion.identity);
        }
        // some spells might be static (no rigid body)
        Rigidbody2D spellRigidBody2D = spell.GetComponent<Rigidbody2D>();
        if (spellRigidBody2D != null)
        {
            spellRigidBody2D.velocity = direction * speed;
        }

        return spell;
    }
}
