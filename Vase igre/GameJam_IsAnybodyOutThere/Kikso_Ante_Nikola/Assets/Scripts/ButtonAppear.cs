using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAppear : MonoBehaviour
{

    public GameObject PlayButton;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(HideAndShow(36.5f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator HideAndShow(float delay)
    {
        PlayButton.SetActive(false);
        yield return new WaitForSeconds(delay);
        PlayButton.SetActive(true);
    }
}