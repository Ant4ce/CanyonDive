using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake()
    {
        Instance = this;
    }
    public void StartMenu()
    {
        Invoke("LoadMenu",0.2f);
    }
    void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PostDeath");
    }
}
