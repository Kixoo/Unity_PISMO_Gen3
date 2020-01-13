using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    public Transform asteroidParent;

    public float minVer = 1.5f;
    public float maxVer = 7.5f;

    public float minHor = -8f;
    public float maxHor = -8;

    public float spawnTimer = 1f;
    public int spawnCount;

    private void Start()
    {
        SpawnAsteroids(spawnCount);
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnAsteroid();
            spawnTimer = 1f;
        }
    }

    public void SpawnAsteroids(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float xCoord = Random.Range(-8, 8);
            float yCoord = Random.Range(2, 7);
            int asteroidDirection = Random.Range(0, 2) < 1 ? -1 : 1;

            var asteroidSpawned = Instantiate(asteroid, new Vector3(xCoord, yCoord, 0f), Quaternion.identity, asteroidParent);
            asteroid.GetComponent<Asteroid>().direction = asteroidDirection;
        }

    }

    public void SpawnAsteroid()
    {
        float xCoord = 9;
        int directionMoving = 1;

        if (Random.Range(0, 2) == 0)
        {
            xCoord = -9;
            directionMoving = 1;
        }
        else
        {
            xCoord = 9;
            directionMoving = -1;
        }

        float yCoord = Random.Range(minVer, maxVer);

        var asteroidSpawned = Instantiate(asteroid, new Vector3(xCoord, yCoord, 0f), Quaternion.identity, asteroidParent);
        asteroidSpawned.GetComponent<Asteroid>().direction = directionMoving;
    }

}
