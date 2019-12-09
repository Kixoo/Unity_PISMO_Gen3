using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Znak [] na kraju vrste varijable stvara "array", array nije isto što i lista
    //Služi za spremanje više objekata u istu varijablu
    public GameObject[] objekti;

    public float timeForSpawn = 3; //Vrijeme na početku za koliko spawnamo
    float timeForSpawn_Restart; //Učita početnu vrijednost
    float timeReducer; // Vrijeme za koliko umanjujemo spawn time

    [Header("Game dificulty:")]
    public bool easy = false;
    public bool normal = false;
    public bool hard = false;

    //Dodjelujemo restart vrijednost za time, dodjeljujemo težinu igre
    void Start()
    {
        timeForSpawn_Restart = timeForSpawn; 
        if(easy == true)
        {
            timeReducer = 0.01f;
        }

        else if(normal == true)
        {
            timeReducer = 0.03f;
        }

        else if(hard == true)
        {
            timeReducer = 0.05f;
        }

        //ako nismo ništa izabrali da bude normal mode igre
        else
        {
            timeReducer = 0.03f;
        }
    }

    void Update()
    {
        timeForSpawn -= Time.deltaTime;
        if(timeForSpawn <= 0)
        {
            //Random broj od 0 do broj objekata koje smo stavili u array
            int randBroj = Random.Range(0, objekti.Length);
            //Stvori objekt koji je u arrayu pod tim random brojem, na pozciji sa radnom osi X, te rotacijom 0,0,0)
            Instantiate(objekti[randBroj], new Vector3(Random.Range(-5, 5), 17, 10), Quaternion.identity);
            if(timeForSpawn_Restart > 0.15f)
            {
                timeForSpawn_Restart -= timeReducer;
                timeForSpawn = timeForSpawn_Restart;
            }
            else
            {
                timeForSpawn = timeForSpawn_Restart;
            }
        }
    }
}
