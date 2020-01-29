using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clip5 : MonoBehaviour
{
    public Text Clipboard5;
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
            Clipboard5.text = "Here I am Franjo. Right in front of you. I'm your only friend here and I'll be your last. It was a hard five years together but we stayed together until the end. Farewell.";
            closeText.gameObject.SetActive(true);
            closeAllowed = true;
        }
        else if (closeAllowed == true && Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("Player"))
        {
            Clipboard5.text = "";
            closeText.gameObject.SetActive(false);
            closeAllowed = false;
            SceneManager.LoadScene(3);

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
            Clipboard5.text = "";
            closeText.gameObject.SetActive(false);
            closeAllowed = false;
        }
    }
}


