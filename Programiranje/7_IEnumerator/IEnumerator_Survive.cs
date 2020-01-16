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

    int wood = 10;
    public int food = 100;
    int gold = 15;
    int population = 100;

    bool GameOver = false;

    private void Start()
    {

        WoodText.text = "Wood: " + wood;
        FoodText.text = "Food: " + food;
        GoldText.text = "Gold: " + gold;
        PopulationText.text = "Population: " + population;
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
            wood++;
            WoodText.text = "Wood: " + wood;
            
        }
    }

    IEnumerator FoodIncrease()
    {
        while(GameOver != true)
        {
            yield return new WaitForSeconds(2);
            food += 2;
            FoodText.text = "Food: " + food;
        }
    }

    IEnumerator GoldIncrease()
    {
        while(GameOver != true)
        {
            yield return new WaitForSeconds(3);
            gold++;
            GoldText.text = "Gold: " + gold;
        }
    }

    IEnumerator PopulationIncrease()
    {
        while (GameOver != true)
        {
            yield return new WaitForSeconds(4);
            population++;
            PopulationText.text = "Population: " + population;
            Debug.Log("Populacija: " + population + " " + "Gold: " + gold + "Food: " + food);
            DecreaseFood();
        }
    }

    void DecreaseFood()
    {
        float amount = Random.Range(2f, 10f);
        food -= (int)amount;
        FoodText.text = "Food: " + food;
    }

}
