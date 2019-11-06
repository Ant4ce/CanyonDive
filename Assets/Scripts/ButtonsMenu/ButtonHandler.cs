using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
