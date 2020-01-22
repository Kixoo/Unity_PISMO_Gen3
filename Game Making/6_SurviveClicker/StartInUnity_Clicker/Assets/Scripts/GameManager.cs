using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text WoodText;
    public Text FoodText;
    public Text GoldText;
    public Text PopulationText;
    public Text GameOverText;
    public Text Days;
    public Text Disaster;
    public Text CityRank;

    int wood = 10;
    public int food = 100;
    int gold = 15;
    int population = 100;
    int days = 1;
    int cityRank = 0;

    int minDana = 20;
    int maxDana = 70;

    bool GameOver = false;

    private void Start()
    {
        IsGameLoaded isGameLoaded = FindObjectOfType<IsGameLoaded>();
        if(isGameLoaded.GameLoaded == true)
        {
            wood = PlayerPrefs.GetInt("wood" + GameSaveData.lastUsername);
            food = PlayerPrefs.GetInt("food" + GameSaveData.lastUsername);
            days = PlayerPrefs.GetInt("dan" + GameSaveData.lastUsername);
            population = PlayerPrefs.GetInt("population" + GameSaveData.lastUsername);
            Disaster.text = PlayerPrefs.GetString("vesti" + GameSaveData.lastUsername);
            gold = PlayerPrefs.GetInt("toZla" + GameSaveData.lastUsername);
            cityRank = PlayerPrefs.GetInt("rankNaselja" + GameSaveData.lastUsername);
        }

        WoodText.text = "Wood: " + wood;
        FoodText.text = "Food: " + food;
        GoldText.text = "Gold: " + gold;
        PopulationText.text = "Population: " + population;
        Days.text = "Days: " + days;
        GameOverText.gameObject.SetActive(false);

        StartCoroutine(WoodIncrease());
        StartCoroutine(FoodIncrease());
        StartCoroutine(GoldIncrease());
        StartCoroutine(PopulationIncrease());
        StartCoroutine(Chaos());
        UpdateCityRank();
    }

    private void Update()
    {
        if(food <= 0 && GameOver != true)
        {
            GameOver = true;
            GameOverText.gameObject.SetActive(true);
            Debug.Log("Game Over");
        }
    }

    IEnumerator WoodIncrease()
    {
        while (GameOver != true)
        {
            yield return new WaitForSeconds(1);
            wood += (int)(population / 20);
            WoodText.text = "Wood: " + wood;
            days++;
            Days.text = "Days: " + days;
            UpdateCityRank();
        }
    }

    IEnumerator FoodIncrease()
    {
        while(GameOver != true)
        {
            yield return new WaitForSeconds(2);
            food += 2;
            FoodText.text = "Food: " + food;
            DecreaseFood();
            
        }
    }

    IEnumerator GoldIncrease()
    {
        while(GameOver != true)
        {
            yield return new WaitForSeconds(8);
            gold += (int)(population / 50);
            GoldText.text = "Gold: " + gold;
        }
    }

    IEnumerator PopulationIncrease()
    {
        while (GameOver != true)
        {
            yield return new WaitForSeconds(5);
            population += (int)Random.Range(0, population * 0.1f);
            PopulationText.text = "Population: " + population;
        }
    }

    IEnumerator Chaos()
    {
        while (GameOver != true)
        {
            float nasumicno = Random.Range(minDana, maxDana);
            yield return new WaitForSeconds((int)nasumicno);
            float nasumicnoNesreca = Random.Range(10, 50);
            if(nasumicnoNesreca < 20)
            {
                //Poplava
                population -= (int)Random.Range(0, population * 0.2f);
                PopulationText.text = "Population: " + population;
                food -= (int)Random.Range(food * 0.1f, food * 0.6f);
                FoodText.text = "Food: " + food;
                Disaster.text = "The flood happend, on day: " + days + "\n" + Disaster.text;

            }
            else if(nasumicnoNesreca >= 20 && nasumicnoNesreca < 30)
            {
                //Rat
                population -= (int)Random.Range(population * 0.2f, population * 0.5f);
                PopulationText.text = "Population: " + population;
                food -= (int)Random.Range(food * 0.1f, food * 0.6f);
                FoodText.text = "Food: " + food;
                gold -= (int)Random.Range(gold * 0.1f, gold * 0.8f);
                GoldText.text = "Gold: " + gold;
                wood -= (int)Random.Range(wood * 0.1f, wood * 0.4f);
                WoodText.text = "Wood: " + wood;
                Disaster.text = "Our neighbour attacked us, on day: " + days + "\n" + Disaster.text;
            }
            else if (nasumicnoNesreca >= 30 && nasumicnoNesreca < 40)
            {
                //požar
                population -= (int)Random.Range(population * 0.1f, population * 0.3f);
                PopulationText.text = "Population: " + population;
                food -= (int)Random.Range(food * 0.2f, food * 0.65f);
                FoodText.text = "Food: " + food;
                wood -= (int)Random.Range(wood * 0.3f, wood * 0.85f);
                WoodText.text = "Wood: " + wood;
                Disaster.text = "The wildfire happend, on day: " + days + "\n" + Disaster.text;
            }
            else if(nasumicno >= 40)
            {
                //Bolest
                int randomBroj = (int)Random.Range(population * 0.25f, population * 0.6f);
                population -= randomBroj;
                PopulationText.text = "Population: " + population;
                Disaster.text = "There was outbreak of plague! You lost " + randomBroj + " of population, on day: " + days + "\n" + Disaster.text;
            }
        }
    }

    void DecreaseFood()
    {
        float amount = Random.Range(1, population * 0.1f);
        food -= (int)amount;
        FoodText.text = "Food: " + food;
    }

    //IEnumerator RemoveNews()
    //{
    //    yield return new WaitForSeconds(5);
    //    Disaster.text = "";
    //}

    //CITY NAMES

    void UpdateCityRank()
    {
        if(population < 100)
        {
            cityRank = 0;
        }
        else if(population < 500)
        {
            cityRank = 1;
        }
        else if (population < 1000)
        {
            cityRank = 2;
        }
        else if (population < 10000)
        {
            cityRank = 3;
        }
        else if (population < 100000)
        {
            cityRank = 4;
        }
        else if (population < 300000)
        {
            cityRank = 5;
        }
        else if (population < 1000000)
        {
            cityRank = 6;
        }
        else if (population < 3000000)
        {
            cityRank = 7;
        }
        else if (population < 10000000)
        {
            cityRank = 8;
        }
        else if (population > 10000000)
        {
            cityRank = 9;
        }

        UpdateCityRank_HierarchyName();
    }

    void UpdateCityRank_HierarchyName()
    {
        switch(cityRank)
        {
            case 0:
                CityRank.text = "Hamlet";
                break;
            case 1:
                CityRank.text = "Tribe";
                break;
            case 2:
                CityRank.text = "Village";
                break;
            case 3:
                CityRank.text = "Town";
                break;
            case 4:
                CityRank.text = "Large Town";
                break;
            case 5:
                CityRank.text = "Borough";
                break;
            case 6:
                CityRank.text = "City";
                break;
            case 7:
                CityRank.text = "Metropolis";
                break;
            case 8:
                CityRank.text = "Conurbation";
                break;
            case 9:
                CityRank.text = "Megalopolis";
                break;
        }
    }

    // BUTTONI

    public void SellWood()
    {
        if(wood >= 5)
        {
            wood -= 5;
            gold += 1;

        }
    }

    public void SellAllWood()
    {
        if(wood >= 5)
        {
            gold += (int)(wood / 5);
            wood = 0;
            WoodText.text = "Wood: " + wood;
            GoldText.text = "Gold: " + gold;
        }
    }

    public void BuyFood()
    {
        if(gold >= 1)
        {
            gold--;
            food += 3;
            FoodText.text = "Food: " + food;
            GoldText.text = "Gold: " + gold;
        }
    }

    public void BuyAllFood()
    {
        if (gold >= 1)
        {
            food += 3 * gold;
            gold = 0;
            FoodText.text = "Food: " + food;
            GoldText.text = "Gold: " + gold;
        }

    }

    public void KillPopulation()
    {
        if(population >= 35 && wood >= 5 && gold >= 2)
        {
            population -= 5;
            wood -= 5;
            gold -= 2;
            WoodText.text = "Wood: " + wood;
            GoldText.text = "Gold: " + gold;
            PopulationText.text = "Population: " + population;
        }
    }

    public void StartAWar()
    {
        if(population > 200 && gold > 15 && wood > 50)
        {
            float percentage = Random.Range(0, 100);
            Debug.Log(percentage + " i " + percentage/100);
            population -= (int)(population * Random.Range(0, 0.9f));
            gold += (int)(gold * Random.Range(0, 3.0f));
            wood -= (int)(wood * Random.Range(0, 0.9f));
            food += (int)(food * Random.Range(0, 2.0f));
            WoodText.text = "Wood: " + wood;
            GoldText.text = "Gold: " + gold;
            PopulationText.text = "Population: " + population;
            FoodText.text = "Food: " + food;
        }
    }

    public void Temple()
    {
        if(gold > 4 && population > 150 && wood > 100)
        {
            gold -= 4;
            wood -= 100;
            minDana += 5;
            maxDana += 5;
            WoodText.text = "Wood: " + wood;
            GoldText.text = "Gold: " + gold;
            PopulationText.text = "Population: " + population;
            FoodText.text = "Food: " + food;
        }
    }

    public void StrongerArmy()
    {
        if(gold > 10 && wood > 50)
        {
            //Smanjiti mogućnost umiranja populacije
        }
    }

    public void SaveMyGame()
    {
        PlayerPrefs.SetInt("population" + GameSaveData.lastUsername, population);
        PlayerPrefs.SetInt("gold" + GameSaveData.lastUsername, gold);
        PlayerPrefs.SetInt("wood" + GameSaveData.lastUsername, wood);
        PlayerPrefs.SetInt("dan" + GameSaveData.lastUsername, days);
        PlayerPrefs.SetInt("hrana" + GameSaveData.lastUsername, food);
        PlayerPrefs.SetInt("rankNaselja" + GameSaveData.lastUsername, cityRank);
        PlayerPrefs.SetString("vesti"+ GameSaveData.lastUsername, Disaster.text);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
