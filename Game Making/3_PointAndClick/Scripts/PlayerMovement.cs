using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Skripta za kretanje igrača tamo gdje smo kliknuli lijevim klikom miša

public class PlayerMovement : MonoBehaviour
{
    Vector3 newPosition; //Pozicija na koju igrač treba ići
    RaycastHit hit; //U sebe pohranjuje podatke što je naša zraka(ray) pogodila

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            /*
            * Raycast hit može pohraniti:
            * collider - koji game object, njegove komponente, kako se zove, jel enemy ili player itd
            * što je pogodio (ui, 3d, 2d, terren itd.)
            * koliko je to udaljeno od nas (od mjesta pucanja, do mjesta udara)
            */
            Ray ray; //Ray = nevidjiva zraka, a pohranjuje se vrijednost od kud se puca do kud se puca
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Zraka je ispucana tamo gdje je miš (cursor)

            if(Physics.Raycast(ray, out hit)) //Ako naša zraka nešto pogodi
            {
                if(hit.collider.gameObject.tag == "Movable")
                {
                    newPosition = hit.point;
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, hit.point, 0.1f);
    }
}
