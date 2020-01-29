
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text papir1;
    public Text papir2;
    public Text papir3;
    public Text papir4;
    public Text papir5;
    [SerializeField]
    private Text pickUpText;
    private bool pickUpAllowed;
    private bool pickUpAllowed2;
    [SerializeField]
    private Text closeText;
    private bool closeAllowed;
    private bool closeAllowed2;
    public void Start()
    {
        pickUpText.gameObject.SetActive(false);
        closeText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (pickUpAllowed == true && Input.GetKeyDown(KeyCode.F) && GameObject.FindWithTag("papir1"))
        {
            pickUpText.gameObject.SetActive(false);
            papir1.text = "Hello buddy, you are not alone here in station. I have left clues all over the station in order for you to find me. I am soo lonely so I hope you will find me and maybe have sex if willing? Go in engine room.";
            closeText.gameObject.SetActive(true);
            closeAllowed = true;
        }
        else if (pickUpAllowed2 == true && Input.GetKeyDown(KeyCode.F) && GameObject.FindWithTag("papir2"))
        {
            pickUpText.gameObject.SetActive(false);
            papir2.text = "Sex maybe?";
            closeText.gameObject.SetActive(true);
            closeAllowed2 = true;
        }

        else if (closeAllowed == true && Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("papir1"))
        {
            papir1.text = "";
            closeText.gameObject.SetActive(false);
            closeAllowed = false;

        }
        else if (closeAllowed2 == true && Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("papir2"))
        {
            papir2.text = "";
            closeText.gameObject.SetActive(false);
            closeAllowed2 = false;

        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "papir1")
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;

        }
        else if (collision.gameObject.tag == "papir2")
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed2 = true;

        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "papir1")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
            papir1.text = "";
            closeText.gameObject.SetActive(false);
            closeAllowed = false;
        }
       else if (collision.gameObject.tag == "papir2")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed2 = false;
            papir2.text = "";
            closeText.gameObject.SetActive(false);
            closeAllowed2 = false;
        }
    }
}
