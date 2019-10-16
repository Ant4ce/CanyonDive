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

    public void RestartGame()
    {
        Invoke("LoadGameplay", 0.1f);
    }

    void LoadGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BaseScene");
    }


}
