using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SiblingTracker : MonoBehaviour {
	
	public float ignoreSiblingCollisionDuration = 7.5f;
	private bool ignoringSiblingCollisions;
	
	private List<GameObject> _siblings;
	public List<GameObject> siblings
	{
		set
		{
			_siblings = value;
			IgnoreSiblingCollisions();
			ignoringSiblingCollisions = true;
		}
	}
	
	private float startFixedTime;
	
	void Start()
	{
		startFixedTime = Time.fixedTime;
	}
	
	void FixedUpdate()
	{
		if(Time.fixedTime > startFixedTime + ignoreSiblingCollisionDuration && ignoringSiblingCollisions)
        {
            IgnoreSiblingCollisions(false);
            ignoringSiblingCollisions = false;
        }
	}
	
  	private void IgnoreSiblingCollisions(bool ignore = true) //Don't collide with other "waves"
    {
        Collider2D collider2D = GetComponent<Collider2D>();

        foreach(GameObject sibling in _siblings)
        {
            if(sibling != null)
            {
                Physics2D.IgnoreCollision(collider2D, sibling.GetComponent<Collider2D>(), ignore);
            }
        }
    }	
	
}
