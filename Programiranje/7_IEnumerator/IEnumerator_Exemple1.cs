using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumerator_Exemple1 : MonoBehaviour
{
    public string ourText;

    private void Start()
    {
        //Pozvali smo ienumerator
        StartCoroutine(WaitAndPrint());
    }

    IEnumerator WaitAndPrint()
    {
        //Čekamo 2 sekunde
        yield return new WaitForSeconds(2);
        Debug.Log(ourText);
    }
}
