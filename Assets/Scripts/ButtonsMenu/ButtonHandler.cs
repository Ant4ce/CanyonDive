using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("BaseScene");
        weaponTeleport.OnHitCoolDownReset = false;
    }
}
