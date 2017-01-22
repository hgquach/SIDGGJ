using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpell : MonoBehaviour {

    public _UNITY_OBJECT_POOL pool;

    string passThrough;
    float decayTimer;

    public void fire(float baseDirection, float arcWidthDeg, float waveSizeDeg, float speed, string goesThrough, float decay)
    {
        float baseAngleRad = Mathf.Deg2Rad * baseDirection;
        float arcWidthRad = Mathf.Deg2Rad * arcWidthDeg;
        float waveSizeRad = Mathf.Deg2Rad * waveSizeDeg;

        //The math should be -- you're firing a certain amount of shots, every waveSizeDeg.
        //So, 360 at 1 = 360 shots. Right...?
        //Dunno why it spreads out more at 720/2, 1080/3, or 1440/4...

        passThrough = goesThrough;
        decayTimer = decay;

        for (float dAngleRad = 0.0f; dAngleRad <= arcWidthRad / 2; dAngleRad += waveSizeRad)
        {
            float leftAngle = Mathf.Repeat(baseAngleRad - dAngleRad, Mathf.PI * 2);
            float rightAngle = Mathf.Repeat(baseAngleRad + dAngleRad, Mathf.PI * 2);

            // fire spell to the left
            place(leftAngle, speed);
            // fire spell to the right (don't fire duplicate if dAngle = 0 or 2PI
            if (Mathf.Abs(Mathf.Repeat(leftAngle - rightAngle, Mathf.PI * 2)) >= waveSizeRad)
            {
                place(rightAngle, speed);
            }
        }
        
    }

    public void place(float angleRad, float speed)
    {
            GameObject obj = _UNITY_OBJECT_POOL.current.GetPooledObject();

            if (obj == null) return;
            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

            obj.transform.position = transform.position + new Vector3(direction.x, direction.y, -0.1f);
            obj.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x));

            obj.GetComponent<WaveController>().direction = direction;
            obj.GetComponent<WaveController>().speed = speed;
            obj.GetComponent<WaveController>().color = passThrough;

            obj.GetComponent<Decay>().lifeDuration = decayTimer;

            obj.SetActive(true);
    }

}
