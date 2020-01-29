using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clip4 : MonoBehaviour
{
    public Text Clipboard4;
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
            Clipboard4.text = "You are a good man Franjo. Most of people wouldn't have a will to survive this long. I know you thought about suicide many times and I am proud you did not do it. Go in the kitchen, I am waiting for you. ";
            closeText.gameObject.SetActive(true);
            closeAllowed = true;
        }
        else if (closeAllowed == true && Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("Player"))
        {
            Clipboard4.text = "";
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
            Clipboard4.text = "";
            closeText.gameObject.SetActive(false);
            closeAllowed = false;
        }
    }
}


