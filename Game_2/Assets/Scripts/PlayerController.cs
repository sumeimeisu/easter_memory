using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public static int points;

    public GameObject bullet;
    public Camera mainCam;
    public int health;

    RaycastHit hit;

	void Start () 
    {
        points = 0;
	}
		
	void Update () 
    {
        shooting();

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    void shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(bullet, transform.position, transform.rotation);
                Bullet.targetPosition = hit.point;
            }   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            health--;
            Destroy(other.gameObject);
        }
    }
}
