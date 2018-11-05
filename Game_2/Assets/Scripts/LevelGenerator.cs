using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour 
{
    public GameObject cube;
    public GameObject enemy;
    public float spawnTime;
    public int pointsTarget, pointsIncrease;


    int randomX, randomZ, randomFirst, randomZFirst, randomXFirst;

	void Start () 
    {
        generatePlatform();
        InvokeRepeating("spawnEnemies", 0.5f, spawnTime);
	}
		
	void Update () 
    {
        increaseSpeed();
	}

    void increaseSpeed()
    {
        if (PlayerController.points >= pointsTarget)
        {
            if (spawnTime > 0.4f)
            {
                spawnTime -= 0.2f;
                CancelInvoke();
                InvokeRepeating("spawnEnemies", 0.5f, spawnTime);
            }
            else
            {
                spawnTime = 0.4f;
            }

            pointsTarget += pointsIncrease;
        }
    }

    void spawnEnemies()
    {
        randomFirst = Random.Range(0, 2);
        if (randomFirst == 1)
        {
            randomX = Random.Range(-4, 5);
            randomZFirst = Random.Range(0, 2);
            if (randomZFirst == 1)
            {
                randomZ = -4;
            }
            else 
            {
                randomZ = 4;
            }
        }
        else 
        {
            randomZ = Random.Range(-4, 5);
            randomXFirst = Random.Range(0, 2);
            if (randomXFirst == 1)
            {
                randomX = -4;
            }
            else
            {
                randomX = 4;
            }
        }

        Instantiate(enemy, new Vector3(randomX, -0.5f, randomZ), Quaternion.identity);
    }

    void generatePlatform()
    {
        for (int i = -4; i < 5; i++)
        {
            for (int j = -4; j < 5; j++)
            {
                Instantiate(cube, new Vector3(i, -6, j), Quaternion.identity);
            }
        }
    }
}
