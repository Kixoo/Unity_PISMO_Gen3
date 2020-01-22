using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public Scene gameScene;
    public Text welcomeText;

    public Button loadGame;

    public GameObject loadPopup;

    public IsGameLoaded gameLoaded;

    private void Start()
    {
        gameLoaded = FindObjectOfType<IsGameLoaded>();
        loadPopup.SetActive(false);
        welcomeText.text = "WELCOME " + GameSaveData.lastUsername;

        //Ako nemamo save file sa tim user imenom više igrano od 2 dana onda onesposobimo load game button
        if(PlayerPrefs.GetInt("dan" + GameSaveData.lastUsername) < 2)
        {
            loadGame.interactable = false;
        }
    }

    public void LoadExistingFile()
    {
        gameLoaded.GameLoaded = true;

        loadPopup.SetActive(true);

        StartCoroutine(LoadSceneAsync());


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
        //SceneManager.LoadScene(1);
        gameLoaded.GameLoaded = false;

        loadPopup.SetActive(true);

        StartCoroutine(LoadSceneAsync());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadSceneAsync()
    {
        //Učitava scenu u pozadini sadašnje scene
        //Koristimo za izradu loading screena

        //DZ Urediti loading screen (postak, bar koji se puni, loading circle, slike da se mjenjaju itd.)
        Text loadText = loadPopup.GetComponentInChildren<Text>();
        loadText.color = new Color(loadText.color.r, loadText.color.g, loadText.color.b, Mathf.PingPong(Time.time, 1));

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
