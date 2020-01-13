using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    int count;
    public TextMeshProUGUI text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Honey")
        {
            Debug.Log("KRA");
            Destroy(other.gameObject);
            count++;
            text.text = count.ToString();

        }
    }
}
