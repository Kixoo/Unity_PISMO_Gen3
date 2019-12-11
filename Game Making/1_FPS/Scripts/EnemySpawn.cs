using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies; //Svi potencijalni enemy
    public Transform[] spawnpoints; //Sve lokacije stvaranja enemiya
    public float spawnInterval; //Nakon svakih koliko se stvori enemy
    float resetSpawnInterval;

    //NIJE POTREBNO:
    int count; //Koliko je stvoreno enemya

    void Start()
    {
        resetSpawnInterval = spawnInterval;
    }

    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if(spawnInterval <= 0)
        {
            int enemyRandom = Random.Range(0, enemies.Length);
            int spawnRandom = Random.Range(0, spawnpoints.Length);
            Instantiate(enemies[enemyRandom], spawnpoints[spawnRandom].position, spawnpoints[spawnRandom].rotation);
            spawnInterval = resetSpawnInterval;
        }
    }
}
