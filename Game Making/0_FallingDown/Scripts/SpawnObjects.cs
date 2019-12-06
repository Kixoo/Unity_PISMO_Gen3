using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject good;
    public GameObject bad;

    public Transform spawnPosition;

    public float timer = 1;

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            int randStvori = Random.Range(0, 2);
            if(randStvori == 0)
            {
                Instantiate(good, new Vector3(Random.Range(-6, 6), 12, 0), Quaternion.identity);
                timer = 1;
            }
            if (randStvori == 1)
            {
                Instantiate(bad, new Vector3(Random.Range(-6, 6), 12, 0), Quaternion.identity);
                timer = 1;
            }
        }
    }
}
