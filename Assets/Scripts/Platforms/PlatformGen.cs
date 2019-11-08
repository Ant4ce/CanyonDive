using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class PlatformGen : MonoBehaviour
{
    public BoxCollider2D platform1;
    public Rigidbody2D player;
    
    public static Transform current;
    public static float CameraHeight;    
    
    private Vector3 lastPlatformPosition;
    private Vector3 currentPosition;
    private Quaternion currentRotation;
    private float horizontalRange;
    private float camHorizontalPosition;


    // Start is called before the first frame update
    void Start()
    {
        current = GetComponent<Transform>();
        currentPosition = current.position;
        currentRotation = current.rotation;
        camHorizontalPosition = currentPosition.x;
        lastPlatformPosition = currentPosition;
        lastPlatformPosition.y = lastPlatformPosition.y - 5f;
        lastPlatformPosition.z = player.transform.position.z;
        
        var cam = GetComponent<Camera>();
        CameraHeight = cam.orthographicSize;
        horizontalRange = cam.aspect * CameraHeight;
    }

    void Update()
    {
        
    }
    
    //get current position and generate Platforms in limited range above
    private void FixedUpdate()
    {
        var height = current.position.y;
        if (lastPlatformPosition.y <= height + CameraHeight + 5f)
        {
            BoxCollider2D platforms;
            Vector3 newPlatformPosition = NewPlatform(lastPlatformPosition, horizontalRange, height);
            platforms = Instantiate(platform1, newPlatformPosition , currentRotation) as BoxCollider2D;
        }
    }
    
    //This is the method defining the Platforms position and distance
    private Vector3 NewPlatform(Vector3 oldPlatform, float horizontalRange, float height)
    {
        Vector3 newPlatform;
        newPlatform.x = camHorizontalPosition + Random.Range(-horizontalRange,horizontalRange);
        var randomHeightMod = height * Random.Range(0.02f, 0.026f);
        newPlatform.y = 9f + oldPlatform.y + (0.025f * height) + Random.Range(-randomHeightMod, randomHeightMod);
        newPlatform.z = oldPlatform.z;
        lastPlatformPosition = newPlatform;
        return newPlatform;
    }
}
