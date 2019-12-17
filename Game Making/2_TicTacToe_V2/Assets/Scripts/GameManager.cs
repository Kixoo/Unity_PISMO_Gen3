using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Lista sa poljima:")]
    public Image[] spaceList; //Array polja  (tekstualnih komponenata sa buttona)

    [Header("Game over panel (UI):")]
    public GameObject gameOver; //game objekt koji se pojavi kada završi igra
    public Text gameOver_Text; //Text koji se prikaže kada završimo igru

    [Header("Active Game Panel (UI):")]
    public Text playerOneName_Input; //Text za unos scora iz input fielda sa glavnog izbornika
    public Text playerTwoName_Input;
    public Text playerOneName; //Text za prikaz imena u gameu
    public Text playerTwoName;
    public Text scorePlayerOne; //Text za score (pobjeda) u gameu
    public Text scorePlayerTwo;
    int scoreOne; //Brojčani iznos pobjeda igrača jedan
    int scoreTwo;

    [Header("X i O")]
    public Sprite prvi; //Slika prvog znaka
    public Sprite drugi; //Slika drugog znaka
    Sprite aktivan;
    public Text whosTurn;

    [Header("Start Button Settings:")]
    public Sprite mainSprite;

    string side; //Može imati vrijednost "X" ili vrijednost "O"

    public int moves = 0; // Koliko poteza imamo

    void Start() //Služi nam za dodjeljivanje vrijednosti
    {
        gameOver.SetActive(false); //isključen objekt
        aktivan = prvi;
        moves = 0;
    }

    //Mjenja tko je na potezu
    public void ChangeSide()
    {
        if (aktivan == prvi)
        {
            aktivan = drugi;
            whosTurn.text = "Turn: " + playerTwoName.text;
        }
        else
        {
            aktivan = prvi;
            whosTurn.text = "Turn: " + playerOneName.text;
        }
    }

    //Metoda sa uvijetima za kraj igre
    public void EndGame()
    {
        if (spaceList[0].sprite == aktivan && spaceList[1].sprite == aktivan && spaceList[2].sprite == aktivan)
        {
            GameOver();
        }
        else if (spaceList[3].sprite == aktivan && spaceList[4].sprite == aktivan && spaceList[5].sprite == aktivan)
        {
            GameOver();
        }
        else if (spaceList[6].sprite == aktivan && spaceList[7].sprite == aktivan && spaceList[8].sprite == aktivan)
        {
            GameOver();
        }
        else if (spaceList[0].sprite == aktivan && spaceList[3].sprite == aktivan && spaceList[6].sprite == aktivan)
        {
            GameOver();
        }
        else if (spaceList[1].sprite == aktivan && spaceList[4].sprite == aktivan && spaceList[7].sprite == aktivan)
        {
            GameOver();
        }
        else if (spaceList[2].sprite == aktivan && spaceList[5].sprite == aktivan && spaceList[8].sprite == aktivan)
        {
            GameOver();
        }
        else if (spaceList[0].sprite == aktivan && spaceList[4].sprite == aktivan && spaceList[8].sprite == aktivan)
        {
            GameOver();
        }
        else if (spaceList[2].sprite == aktivan && spaceList[4].sprite == aktivan && spaceList[6].sprite == aktivan)
        {
            GameOver();
        }
        else if (moves >= 9)
        {
            gameOver.SetActive(true);
            gameOver_Text.text = "Tie!";
        }

        ChangeSide();
    }

    void GameOver()
    {
        gameOver.SetActive(true);
        if(aktivan == prvi)
        {
            scoreOne++;
            scorePlayerOne.text = scoreOne.ToString();
            gameOver_Text.text = playerOneName.text + " wins!";
        }
        else
        {
            scoreTwo++;
            scorePlayerTwo.text = scoreTwo.ToString();
            gameOver_Text.text = playerTwoName.text + " wins!";
        }
    }

    //Javna string metoda koja vraća isključivo string vrijednosti, te ju ovdje koristimo za povezivanje skripti
    public Sprite GetSide()
    {
        return aktivan;
    }

    //Kada kliknemo play gumb na izborniku
    public void StartGame()
    {
        playerOneName.text = playerOneName_Input.text;
        playerTwoName.text = playerTwoName_Input.text;
        whosTurn.text = "Turn: " + playerOneName.text;
    }

    //Nastavak igre, tako da se gumbi resetiraju, a igra nastavlja 
    public void ContinueGame()
    {
        Button[] gumbi = GameObject.FindObjectsOfType<Button>(); //Uzmemo sve gumbe sa scene
        for(int i = 0; i < gumbi.Length; i++)
        {
            gumbi[i].image.sprite = mainSprite; //resetirana slika
            gumbi[i].interactable = true; //postati interaktivni
        }
        gameOver.SetActive(false);
        moves = 0;
        whosTurn.text = whosTurn.text = "Turn: " + playerOneName.text;
        aktivan = prvi;
    }
}