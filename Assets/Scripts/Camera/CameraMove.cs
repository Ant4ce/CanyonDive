using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // creates a slider for the speedMultiplier variable that allows it to be changed in Unity UI
    // speedMultiplier is variable to be able to change speed of camera 
    [SerializeField]
    [Range(0f, 20f)]
    private float speedMultiplier = 1f;
    //variable to hold and update the y position of the player object
    private float fheight;
    //
    private float rapidite = 1f;

    [SerializeField]
    private float accelf = 0.5f;
    

    void Update()
    {
        fheight = transform.position.y ;


        if (fheight < 100)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speedMultiplier);
        }
        if (fheight >= 100 && fheight < 500)        
        {
            rapidite += accelf;
            transform.Translate(Vector3.up * Time.deltaTime * speedMultiplier * rapidite);
        }if (fheight >= 500)
        {
            rapidite += accelf;
            transform.Translate(Vector3.up * Time.deltaTime * rapidite);
        }

    }
}
