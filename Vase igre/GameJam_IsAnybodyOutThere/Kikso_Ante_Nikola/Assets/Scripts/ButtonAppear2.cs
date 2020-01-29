using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAppear2 : MonoBehaviour
{

    public GameObject RestartButton;
    public GameObject QuitButton;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(HideAndShow(26.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator HideAndShow(float delay)
    {
        RestartButton.SetActive(false);
        QuitButton.SetActive(false);
        yield return new WaitForSeconds(delay);
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
    }
}