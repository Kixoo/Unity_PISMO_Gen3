using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//RADIMO SA PROJEKTILIMA, A NE SA RAYCASTOM

public class Gun : MonoBehaviour
{
    [Header("Municija:")]
    public int maxAmmo; //iznos koliko imamo početne municije
    int currentAmmo; //Koliko u ovom trenutku imamo munije
    public Text ammo; //ispisuje koliko imamo metaka;

    [Header("Metak:")]
    public GameObject bullet; //prefab metka koji puca ta puška
    public Transform bulletSpawnPoint; //mjesto gdje se metak stvara (izlaz cijevi na oružju)
    AudioSource zvukPucanja; //komponenta mora biti na oružju

    [Header("O oružju:")]
    public float Recoil; //Trzaj
    public float reloadTime; //Brzina mjenjanja municije
    public Camera aimScope; //Kamera na oružju za zoom
    //Vrste pucanja
    [Header("Vrsta pucanja: (Samo jedan bool aktivan!)")]
    public bool singleFire = false; //Pucamo jedan metak po kliku miša
    public bool automaticFire = false; //Držimo i pucamo metke ovisno o fire rateu
    public bool burstFire = false; //Pucamo 3 metka po kliku miša
}
