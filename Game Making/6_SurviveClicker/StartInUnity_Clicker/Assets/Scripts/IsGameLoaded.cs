using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGameLoaded : MonoBehaviour
{
    public bool GameLoaded;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
