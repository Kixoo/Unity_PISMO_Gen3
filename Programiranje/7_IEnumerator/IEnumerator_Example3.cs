using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumerator_Example3 : MonoBehaviour
{
    public string ourText;

    int counter = 0;

    private void Start()
    {
        StartCoroutine(Something());
    }

    IEnumerator Something()
    {
        while (true)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(counter, counter, 0);

            Debug.Log(ourText + " " + Time.time);
            counter++;
            yield return new WaitForSeconds(1);

        }
    }

}
