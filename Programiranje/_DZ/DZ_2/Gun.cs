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
    public Rigidbody bullet; //prefab metka koji puca ta puška
    public Transform bulletSpawnPoint; //mjesto gdje se metak stvara (izlaz cijevi na oružju)
    AudioSource zvukPucanja; //komponenta mora biti na oružju

    [Header("O oružju:")]
    public float Accuracy; //Preciznost oružja (odstupanje u milimetrima)
    public float Recoil; //Trzaj
    public float reloadTime; //Brzina mjenjanja municije
    float reloadTimeStart;
    public Camera aimScope; //Kamera na oružju za zoom
    public float fireRateStart; //koliki je razmak vremenski između metaka
    float fireRate;
    //Vrste pucanja
    [Header("Vrsta pucanja: (Samo jedan bool aktivan!)")]
    public bool singleFire = false; //Pucamo jedan metak po kliku miša
    public bool automaticFire = false; //Držimo i pucamo metke ovisno o fire rateu
    public bool burstFire = false; //Pucamo 3 metka po kliku miša
    int vrstaPucanja;

    void Start()
    {
        currentAmmo = maxAmmo; //Postavljamo da na početku imamo maksimalni iznos metaka u šanžeru
        aimScope.gameObject.SetActive(false); //deaktivirali smo gameobject kamere za scope
        ammo.text = currentAmmo + "/" + maxAmmo; //prikazuje nam na UI iznos metaka
        zvukPucanja = GetComponent<AudioSource>();
        fireRate = fireRateStart;
        reloadTimeStart = reloadTime;

        if(singleFire == true)
        {
            vrstaPucanja = 0;
        }
        else if(automaticFire == true)
        {
            vrstaPucanja = 1;
        }
        else if(burstFire == true) //DZ 
        {
            vrstaPucanja = 2;
        }
    }

    void FixedUpdate()
    {
        fireRate -= Time.deltaTime; //Oduzimamo pravo vrijeme za ponovo pucanje
        reloadTime -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && vrstaPucanja == 0 && currentAmmo > 0 && fireRate <= 0)
        {
            Pucaj();
            fireRate = fireRateStart;
        }
        else if (Input.GetMouseButtonDown(0) && vrstaPucanja == 1 && currentAmmo > 0 && fireRate <= 0)
        {
            Pucaj();
            fireRate = fireRateStart;
        }
        //DZ ZA BURST FIRE
        else if(Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            reloadTime = reloadTimeStart;
            currentAmmo = maxAmmo;
            ammo.text = currentAmmo + "/" + maxAmmo;
        }
        else if(Input.GetMouseButtonDown(1))
        {
            aimScope.gameObject.SetActive(true);
            //pronalazimo glavnu kameru na igracu i dajemo joj vrijednost u varijablu fpsKamera
            GameObject fpsKamera = GameObject.FindGameObjectWithTag("MainCamera");
            //deaktiviraj glavnu kameru
            fpsKamera.GetComponent<Camera>().enabled = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            aimScope.gameObject.SetActive(false);
            //pronalazimo glavnu kameru na igracu i dajemo joj vrijednost u varijablu fpsKamera
            GameObject fpsKamera = GameObject.FindGameObjectWithTag("MainCamera");
            //deaktiviraj glavnu kameru
            fpsKamera.GetComponent<Camera>().enabled = true;
        }
    }

    void Pucaj()
    {
        float x = Screen.width / 2;
        float x_Accuracy = Random.Range(x - Accuracy, x + Accuracy);
        float y = Screen.height / 2;
        float y_Accuracy = Random.Range(y - Accuracy, y + Accuracy);

    }
}
