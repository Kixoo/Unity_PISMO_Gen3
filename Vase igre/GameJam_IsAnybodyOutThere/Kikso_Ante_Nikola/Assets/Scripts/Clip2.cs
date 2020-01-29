using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clip2 : MonoBehaviour
{
    public Text Clipboard2;
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
            Clipboard2.text = "I know what you did last summer Franjo... hahahha Im only joking. I know you are lonely but soon you'll meet me. Go in the bathroom";
            closeText.gameObject.SetActive(true);
            closeAllowed = true;
        }
        else if (closeAllowed == true && Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("Player"))
        {
            Clipboard2.text = "";
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
            Clipboard2.text = "";
            closeText.gameObject.SetActive(false);
            closeAllowed = false;
        }
    }
}


