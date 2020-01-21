using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSaveData
{
    public static int highestPopulation = PlayerPrefs.GetInt("population");
    public static int highestWood = PlayerPrefs.GetInt("wood");
    public static int highestGold = PlayerPrefs.GetInt("gold");
    public static int highestDay = PlayerPrefs.GetInt("dan");
    public static int highestFood = PlayerPrefs.GetInt("hrana");
    public static int highestRank = PlayerPrefs.GetInt("rankNaselja");
    public static string allNews = PlayerPrefs.GetString("vesti");

    //Načini pristupa podatak
    //void Start()
    //{
    //    population = PlayerPrefs.GetInt("population");
    //    poulation = GameSaveData.highestPopulation;
    //}
}
