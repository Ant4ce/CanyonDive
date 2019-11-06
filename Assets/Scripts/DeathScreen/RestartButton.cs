using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        //GameManager.instance.PlayGame();
        SceneManager.LoadScene("BaseScene");
        weaponTeleport.onHitCoolDown = false;
    }
}
