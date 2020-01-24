using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke_Exemple1 : MonoBehaviour
{
    public string name;
    //Invoke služi za zvanje metoda u određenom vremeu (sekunde)
    //U invoke zvome metode iz te skripte

    private void Start()
    {
        Invoke("IspisiMojeIme", 2.0f);
    }

    void IspisiMojeIme()
    {
        Debug.Log("Moje ime je: " + name);
    }
}
