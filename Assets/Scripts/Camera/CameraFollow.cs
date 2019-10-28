using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //these variables are used for the follow function
    public Transform target;
    public float smoothingspeed = 0.2f;
  
    public float min_Y_offset = 2.6f;
    private bool follow_player;

    // these variables are used for the Smoothstlk function, the ones below are only used for the Smoothstalk script. wherease the ones above are also used in update

    public GameObject thingToFollow;

    [SerializeField]
    [Range(0f, 10f)]
    private float speed = 2.0f;


    private void FixedUpdate()
    {
        //Follow();

        //use the one below or above not both at the same time

        Smoothstalk();
    }
    
    //method to follow player by spaing to the position of the player
    void Follow()
    {
        //makes the camera stop following player if player is bellow certain threshold 
        if (target.position.y < (transform.position.y + min_Y_offset ))
        {
            follow_player = false;
        }// camera follows player if above threshold
        if (target.position.y > transform.position.y)
        {
            follow_player = true;

        }
        if (follow_player)
        {
            Vector3 temporary = transform.position; 
            temporary.y = target.position.y;
            transform.position = temporary;    
        }
        
    }

    // method that follows the player but doesnt snap to player instantly, rather it catches up
    void Smoothstalk()
    {
        // multiply by deltatime to make sure it is independant of frame rate
        float interpolation = speed * Time.deltaTime;

        Vector3 positiontobe = this.transform.position;

        //use lerp to smoothly transition the camera to new position
        //positiontobe.y = Mathf.Lerp(this.transform.position.y, thingToFollow.transform.position.y, interpolation);

        //Mathf.Max is used here to ensure that the lerp only can follow the player up not down. 
        positiontobe.y = Mathf.Lerp(this.transform.position.y, Mathf.Max(thingToFollow.transform.position.y, this.transform.position.y), interpolation);

        this.transform.position = positiontobe;
    }
}
