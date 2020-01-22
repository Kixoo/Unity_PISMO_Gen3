using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSaveData
{
    public static int highestPopulation = PlayerPrefs.GetInt("population" + lastUsername);
    public static int highestWood = PlayerPrefs.GetInt("wood" + lastUsername);
    public static int highestGold = PlayerPrefs.GetInt("gold" + lastUsername);
    public static int highestDay = PlayerPrefs.GetInt("dan" + lastUsername);
    public static int highestFood = PlayerPrefs.GetInt("hrana" + lastUsername);
    public static int highestRank = PlayerPrefs.GetInt("rankNaselja" + lastUsername);
    public static string allNews = PlayerPrefs.GetString("vesti" + lastUsername);
    public static string lastUsername = PlayerPrefs.GetString("username");

    //Načini pristupa podatak
    //void Start()
    //{
    //    population = PlayerPrefs.GetInt("population");
    //    poulation = GameSaveData.highestPopulation;
    //}
}
