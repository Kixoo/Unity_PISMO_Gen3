using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    float health_Start;
    public float health_Current;

    public float healthReg;

    void Start()
    {
        health_Start = health;
        health_Current = health;
    }

    void Update()
    {
        if(health_Current < health_Start)
        {
            health_Current += healthReg * Time.deltaTime;
        }
        if(health_Current <= 0)
        {
            Application.Quit();
            Debug.Log("Game over maderfaker");
        }
    }
}
