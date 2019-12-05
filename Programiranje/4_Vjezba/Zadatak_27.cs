using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zadatak_27 : MonoBehaviour
{
    public string nekiTekst;
    public Text UI_Text;

    void Start()
    {
        UI_Text.text = nekiTekst;
    }
}
