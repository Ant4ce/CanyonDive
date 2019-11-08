using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruct : MonoBehaviour
{
	private float screenheight;
	private float platformheight;
	private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
		platformheight = GetComponent<Transform>().position.y;
		screenheight = PlatformGen.CameraHeight;
    }

    // Update is called once per frame
    void Update()
    {
	    var playerheight = PlatformGen.current.position.y;
	    if (platformheight <= playerheight - screenheight){
			Destroy(gameObject);	
		}
    }    
}
