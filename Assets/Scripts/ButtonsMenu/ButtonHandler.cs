using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        //GameManager.instance.PlayGame();
        SceneManager.LoadScene("BaseScene");
        weaponTeleport.onHitCoolDown = false;
    }
}
