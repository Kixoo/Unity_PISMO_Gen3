using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public Scene gameScene;

    public IsGameLoaded gameLoaded;

    public void LoadExistingFile()
    {
        gameLoaded.GameLoaded = true;
        SceneManager.LoadScene(1);
        Debug.Log("pop: " + GameSaveData.highestPopulation);
        Debug.Log("dan: " + GameSaveData.highestDay);
        Debug.Log("rana: " + GameSaveData.highestFood);
        Debug.Log("toZla: " + GameSaveData.highestGold);
        Debug.Log("stojko: " + GameSaveData.highestWood);
        Debug.Log("vesti: " + GameSaveData.allNews);
    }

    public void NewGame()
    {
        //SceneManager.LoadScene(gameScene.name);
        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
