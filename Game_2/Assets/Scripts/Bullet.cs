using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{	    
    public static Vector3 targetPosition;
    public float speed;

    Vector3 directionVector;
    bool destroyed;

    void Start () 
    {
        targetPosition.y = -0.5f;
        directionVector = (targetPosition - transform.position).normalized;
	}
		
	void Update () 
    {
        moveTowardsTarget();

        if (!destroyed)
        {
            Destroy(this.gameObject, 2);
            destroyed = true;
        }
	}

    void moveTowardsTarget()
    {
        transform.position += directionVector * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {            
            Destroy(this.gameObject);
        }
    }
}
