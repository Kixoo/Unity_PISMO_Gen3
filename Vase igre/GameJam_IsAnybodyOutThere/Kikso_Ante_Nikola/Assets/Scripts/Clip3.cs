using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clip3 : MonoBehaviour
{
    public Text Clipboard3;
    [SerializeField]
    private Text pickUpText;
    private bool pickUpAllowed;
    [SerializeField]
    private Text closeText;
    private bool closeAllowed;
    public void Start()
    {
        pickUpText.gameObject.SetActive(false);
        closeText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (pickUpAllowed == true && Input.GetKeyDown(KeyCode.F) && GameObject.FindWithTag("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            Clipboard3.text = "I'm sorry this happened to you I watched you everyday since you arrived there and I know how hard it was for you to be here alone for so long but everything will be over soon. Next Clipboard above.";
            closeText.gameObject.SetActive(true);
            closeAllowed = true;
        }
        else if (closeAllowed == true && Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("Player"))
        {
            Clipboard3.text = "";
            closeText.gameObject.SetActive(false);
            closeAllowed = false;

        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
            Clipboard3.text = "";
            closeText.gameObject.SetActive(false);
            closeAllowed = false;
        }
    }
}


