using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_2 : MonoBehaviour
{
    [Header("Upiši iznos trajnja razine u minutama")]
    public float minute;

    [Header("Upiši iznost trajanja razine u sekundama")]
    public float sekunde;

    [Header("Dodjeli text na kojem se prikazuje vrijeme")]
    public Text time_text;

    float ukupnoVrijeme;

    private void Start()
    {
        if(sekunde >= 60)
        {
            Debug.LogError("DEBILU, KAKO MOŽE BITI VIŠE OD 59 SEKUNDI?!");
            Debug.Break(); //Pauzira Unity Editor Play
        }
        if(minute >= 60)
        {
            Debug.LogError("GLUPANE, KAKO MOŽE BITI VIŠE OD 59 MINUTA?!");
            Debug.Break(); //Pauzira Unity Editor Play
        }
        ukupnoVrijeme = minute * 60 + sekunde;
    }

    private void Update()
    {
        ukupnoVrijeme -= Time.deltaTime;

        if (ukupnoVrijeme >= 0)
        {
            //Djelimo sa cijelim brojem da dobijemo minute
            float minutes = (int)(ukupnoVrijeme / 60);
            //Dijelimo sa 60 da dobijemo ostatak % služi za takvo djeljenje
            float seconds = Mathf.FloorToInt(ukupnoVrijeme % 60);

            //Ako je manje od 10 brojčano za minute i sekunde
            if (minute < 10 && seconds < 10)
            {
                time_text.text = "0" + minutes + ":" + "0" + seconds;
            }

            //minute su jednoznamenkaste, a sekunde dvoznamenkaste
            else if (minutes < 10 && seconds >= 10)
            {
                time_text.text = "0" + minutes + ":" + seconds;
            }

            //Minute su dvoznamenkaste, a sekunde jednoznamenkaste
            else if (minute >= 10 && seconds < 10)
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
