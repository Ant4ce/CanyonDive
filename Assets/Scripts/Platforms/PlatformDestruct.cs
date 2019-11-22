using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruct : MonoBehaviour
{
	private float screenHeight;
	private float platformHeight;
	private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
		platformHeight = GetComponent<Transform>().position.y;
		screenHeight = PlatformGen.VerticalCameraSize;
    }

    // Update is called once per frame
    void Update()
    {
	    var playerheight = PlatformGen.Current.position.y;
	    if (platformHeight <= playerheight - screenHeight){
			Destroy(gameObject);	
		}
    }    
}
