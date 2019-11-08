using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruct : MonoBehaviour
{
	private float screenheight;
	private float platformheight;
	private float playerheight;

    // Start is called before the first frame update
    void Start()
    {
        Transform playerPosition = PlatformGen.GetHeight();
		playerheight = playerPosition.GetComponent<Transform>().position.y;
		platformheight = GetComponent<Transform>().position.y;
		screenheight = PlatformGen.CameraHeight;
		Debug.Log(playerheight);
		Debug.Log(screenheight);
    }

    // Update is called once per frame
    void Update()
    {
	    Debug.Log(playerheight);
	    if (platformheight <= playerheight - screenheight){
	        //Debug.Log(platformheight);
			Destroy(gameObject);	
		}
    }    
}
