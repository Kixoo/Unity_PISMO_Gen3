using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource zvuk;

    //Metoda koja nam služi da kad pomaknemo slider, zvuk se promjeni
    public void SetVolume()
    {
        zvuk.volume = volumeSlider.value;
    }
}
