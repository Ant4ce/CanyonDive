using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //these variables are used for the follow function
    public Transform target;
    public float smoothingspeed = 0.2f;
  
    public float min_Y_offset = -2.6f;
    private bool follow_player;

    // these variables are used for the Smoothstlk function, the ones below are only used for the Smoothstalk script. wherease the ones above are also used in update

    public GameObject thingToFollow;

    [SerializeField]
    [Range(0f, 10f)]
    private float speed = 2.0f;


    private void Update()
    {
        //Follow();

        //use the one below or above not both at the same time

        if (target.position.y < (transform.position.y - min_Y_offset))
        {

        }
        if (target.position.y > transform.position.y)
        {
            Smoothstalk();
        }
    }

    void Follow()
    {
        if (target.position.y < (transform.position.y - min_Y_offset ))
        {
            follow_player = false;
        }
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

    void Smoothstalk()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 positiontobe = this.transform.position;

        positiontobe.y = Mathf.Lerp(this.transform.position.y, thingToFollow.transform.position.y, interpolation);

        this.transform.position = positiontobe;
    }
}
