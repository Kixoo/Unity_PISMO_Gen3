using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //U ovu vrijednost upisujem brzinu kretanja
    public float speed;

    void Update()
    {
        transform.position += new Vector3(0, 0, speed);
    }

    /*
     * Kako bi OnTrigger i OnCollision radili potrebno je da barme jedan od dva objekta 
     * ima na sebi komponentu Rigidbody (FIZIKA)
     * Kako bi on trigger radio potrebno je da JEDAN (Ne oba) objekt ima na sebi u komponenti
     * Collider označeno kvačicom isTrigger da je točno
     */

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Ušao sam u trigger!");
        //Destroy(other.gameObject); 
        /*
        This uništava samo skriptu, a sa this.gameobject uništavamo cijeli objekt!
        -------
        other ne predstavlja direktan prijevod nego je naziv varijable vrste Collider
        OnTrigger Gleda Collider varijable zato što one služe kao zid objekata
        */
    }

    void OnTriggerStay(Collider other)
    {

    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Izašao sam iz triggera!");
        Destroy(other.gameObject);
    }
}
