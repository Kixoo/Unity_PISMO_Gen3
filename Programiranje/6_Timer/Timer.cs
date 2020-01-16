using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Upiši broj minuta za razinu")]
    public float minute;

    public Text time_text;

    private void Start()
    {
        minute *= 60; //Pretvaramo minute u sekunde
    }

    private void Update()
    {
        minute -= Time.deltaTime;

        if(minute >= 0)
        {
            //Djelimo sa cijelim brojem da dobijemo minute
            float minutes = (int)(minute / 60);
            //Dijelimo sa 60 da dobijemo ostatak % služi za takvo djeljenje
            float seconds = Mathf.FloorToInt(minute % 60);

            //Ako je manje od 10 brojčano za minute i sekunde
            if(minute < 10 && seconds < 10)
            {
                time_text.text = "0" + minutes + ":" + "0" + seconds;
            }

            //minute su jednoznamenkaste, a sekunde dvoznamenkaste
            else if(minutes < 10 && seconds >= 10)
            {
                time_text.text = "0" + minutes + ":" + seconds;
            }

            //Minute su dvoznamenkaste, a sekunde jednoznamenkaste
            else if(minute >= 10 && seconds < 10)
            {
                time_text.text = minutes + ":" + "0" + seconds;
            }

            //Minute i sekunde su dvoznamenkaste
            else
            {
                time_text.text = minutes + ":" + seconds;
            }

        }
    }
}
