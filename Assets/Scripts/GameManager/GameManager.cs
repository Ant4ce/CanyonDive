using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //public void PlayGame()
    //{
    //    Invoke("LoadGameplay", 0.1f);
    //}

    public void StartMenu()
    {
        Invoke("LoadMenu", 0.2f);
    }

    //void LoadGameplay()
    //{
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("BaseScene");
    //}

    void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PostDeath");

    }


}
