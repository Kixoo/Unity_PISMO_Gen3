using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Lista sa poljima:")]
    public Text[] spaceList; //Array polja  (tekstualnih komponenata sa buttona)

    [Header("Game over panel (UI):")]
    public GameObject gameOver; //game objekt koji se pojavi kada završi igra
    public Text gameOver_Text; //Text koji se prikaže kada završimo igru

    string side; //Može imati vrijednost "X" ili vrijednost "O"

    public int moves = 0; // Koliko poteza imamo

    void Start() //Služi nam za dodjeljivanje vrijednosti
    {
        gameOver.SetActive(false); //isključen objekt
        side = "X";
        moves = 0;
    }

    //Mjenja tko je na potezu
    public void ChangeSide()
    {
        if (side == "X")
        {
            side = "O";
        }
        else
        {
            side = "X";
        }
    }

    //Metoda sa uvijetima za kraj igre
    public void EndGame()
    {
        if (spaceList[0].text == side && spaceList[1].text == side && spaceList[2].text == side)
        {
            GameOver();
        }
        else if(spaceList[3].text == side && spaceList[4].text == side && spaceList[5].text == side)
        {
            GameOver();
        }
        else if (spaceList[6].text == side && spaceList[7].text == side && spaceList[8].text == side)
        {
            GameOver();
        }
        else if (spaceList[0].text == side && spaceList[3].text == side && spaceList[6].text == side)
        {
            GameOver();
        }
        else if (spaceList[1].text == side && spaceList[4].text == side && spaceList[7].text == side)
        {
            GameOver();
        }
        else if (spaceList[2].text == side && spaceList[5].text == side && spaceList[8].text == side)
        {
            GameOver();
        }
        else if (spaceList[0].text == side && spaceList[4].text == side && spaceList[8].text == side)
        {
            GameOver();
        }
        else if (spaceList[2].text == side && spaceList[4].text == side && spaceList[6].text == side)
        {
            GameOver();
        }
        else if(moves >= 9)
        {
            gameOver.SetActive(true);
            gameOver_Text.text = "Tie!";
        }

        ChangeSide();
    }

    void GameOver()
    {
        gameOver.SetActive(true);
        gameOver_Text.text = side + " wins!";
    }

    //Javna string metoda koja vraća isključivo string vrijednosti, te ju ovdje koristimo za povezivanje skripti
    public string GetSide()
    {
        return side;
    }
}
