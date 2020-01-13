using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float TimerReset;
    private float Timer;
    public GameObject ObjectToSpawn;
    public Vector3 SpawnPositions;

    private void Start()
    {
        Timer = TimerReset;
        SpawnObjects();
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0f)
        {
            SpawnObjects();
        }
    }

    void SpawnObjects()
    {
        Instantiate(ObjectToSpawn, new Vector3(SpawnPositions.x, Random.Range(-0.5f, SpawnPositions.y), 0), Quaternion.identity);
        Timer = TimerReset;
    }
}
