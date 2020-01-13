using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject obsticle1;
    public GameObject obsticle2;

    void Update()
    {
        if(obsticle1 != null)
        {
            obsticle1.transform.position += new Vector3(0.05f, 0f, 0f);
        }

        if (obsticle2 != null)
        {
            obsticle2.transform.position -= new Vector3(0.05f, 0f, 0f);
        }
    }
}
