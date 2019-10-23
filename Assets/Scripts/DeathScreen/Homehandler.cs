using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Homehandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        //GameManager.instance.PlayGame();
        SceneManager.LoadScene("GameMenu");
    }
}
