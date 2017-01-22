using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpell : MonoBehaviour {

    public _UNITY_OBJECT_POOL pool;

    public void fire(float baseDirection, float arcWidthDeg, float waveSizeDeg, float speed, string goesThrough)
    {
        float baseAngleRad = Mathf.Deg2Rad * baseDirection;
        float arcWidthRad = Mathf.Deg2Rad * arcWidthDeg;
        float waveSizeRad = Mathf.Deg2Rad * waveSizeDeg;

        GameObject obj = _UNITY_OBJECT_POOL.current.GetPooledObject();

        if (obj == null) return;
        Vector2 direction = new Vector2(Mathf.Cos(waveSizeRad), Mathf.Sin(waveSizeRad));

        obj.transform.position = transform.position + new Vector3(direction.x, direction.y, -0.1f);
        obj.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x));

        obj.GetComponent<WaveController>().direction = direction;
        obj.GetComponent<WaveController>().speed = speed;
        obj.GetComponent<WaveController>().color = goesThrough;

        obj.SetActive(true);

    }

}
