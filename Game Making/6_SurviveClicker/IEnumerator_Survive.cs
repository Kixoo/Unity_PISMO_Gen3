using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IEnumerator_Survive : MonoBehaviour
{
    public Text WoodText;
    public Text FoodText;
    public Text GoldText;
    public Text PopulationText;
    public Text GameOverText;
    public Text Days;

    int wood = 10;
    public int food = 100;
    int gold = 15;
    int population = 100;
    int days = 1;

    bool GameOver = false;

    private void Start()
    {

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
            wood += (int)(population / 50);
            WoodText.text = "Wood: " + wood;
            days++;
            Days.text = "Days: " + days;
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
            gold += (int)(population / 100);
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

    void DecreaseFood()
    {
        float amount = Random.Range(1, population * 0.1f);
        food -= (int)amount;
        FoodText.text = "Food: " + food;
    }


    // BUTTONI

    public void SellWood()
    {
        if(wood >= 5)
        {
            wood -= 5;
            gold += 1;
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

    public void KillPopulation()
    {
        if(population >= 35 && wood >= 5 && gold >= 2)
        {
            population -= 5;
            wood -= 5;
            gold -= 2;
            WoodText.text = "Wood: " + food;
            GoldText.text = "Gold: " + gold;
            PopulationText.text = "Population: " + population;
        }
    }

}
