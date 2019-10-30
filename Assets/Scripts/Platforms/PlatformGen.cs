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
    
    private Vector3 lastPlatformPosition;
    private Vector3 currentPosition;
    private Quaternion currentRotation;
    private float[] horizontalRange = {-2.5f, 2.5f}; //TODO: adept flexibly to screen size
    private float camHorizontalPosition;

    // Start is called before the first frame update
    void Start()
    {
        Transform current = GetComponent<Transform>();
        currentPosition = current.position;
        currentRotation = current.rotation;
        camHorizontalPosition = currentPosition.x;
        lastPlatformPosition = currentPosition;
        lastPlatformPosition.y = lastPlatformPosition.y - 5f;
        lastPlatformPosition.z = player.transform.position.z;
    }

    void Update()
    {
        
    }
    
    //get current position and generate Platforms in limited range above
    private void FixedUpdate()
    {
        var height = currentPosition.y;
        if (lastPlatformPosition.y <= height + 100f)
        {
            BoxCollider2D platforms;
            Vector3 newPlatformPosition = NewPlatform(lastPlatformPosition, horizontalRange, height);
            platforms = Instantiate(platform1, newPlatformPosition , currentRotation) as BoxCollider2D;
        }
    }
    
    //This is the method defining the Platforms position and distance
    private Vector3 NewPlatform(Vector3 oldPlatform, float[] horizontalRange, float height)
    {
        Vector3 newPlatform;
        newPlatform.x = camHorizontalPosition + Random.Range(horizontalRange[0],horizontalRange[1]);
        var randomHeightMod = height * Random.Range(0.02f, 0.026f);
        newPlatform.y = 3f + oldPlatform.y + 1.01f * height + Random.Range(-randomHeightMod, randomHeightMod);
        newPlatform.z = oldPlatform.z;
        lastPlatformPosition = newPlatform;
        return newPlatform;
    }
}
