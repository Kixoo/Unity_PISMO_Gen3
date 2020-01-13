using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Obsticle;
    public GameObject Obsticle2;
    public float random;
    public float random2;
    public float speed;

    void Start()
    {
        StartCoroutine(Spawning(1f));
    }

    private void Update()
    {
        random = Random.Range(-2f, 4.5f);
        random2 = Random.Range(-2f, 4.5f);
    }

    IEnumerator Spawning(float amount)
    {
        while(true)
        {
            yield return new WaitForSeconds(0.8f);
            Instantiate(Obsticle, new Vector2(-12f, random), transform.rotation);
            Instantiate(Obsticle2, new Vector2(12f, random2), transform.rotation);
        }
    }
}
