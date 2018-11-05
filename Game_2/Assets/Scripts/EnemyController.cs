using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
    public int health;
    public float speed;

    Vector3 targetPosition;
    Vector3 directoryVector;

	void Start () 
    {
        targetPosition = new Vector3(0, -0.5f, 0);
        directoryVector = (targetPosition - transform.position).normalized;
        speed = Random.Range(0.2f, 1f);
	}
		
	void Update () 
    {
        moveTowardsTarget();

        if (health <= 0)
        {
            PlayerController.points++;
            Debug.Log(PlayerController.points);
            Destroy(this.gameObject);
        }
	}

    void moveTowardsTarget()
    {
        transform.position += directoryVector * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health--;
        }
    }
}
