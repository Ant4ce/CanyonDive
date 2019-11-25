using UnityEngine;
using UnityEngine.SceneManagement;

public class Homehandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
