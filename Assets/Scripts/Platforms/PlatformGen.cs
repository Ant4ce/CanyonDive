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
    private Vector3 currentposition;
    private Quaternion currentrotation;
    private float[] horizontalRange = {-2.5f, 2.5f}; //TODO: adept flexibly to screen size
    private float camHorizontalPosition;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 cameraPosition = GetComponent<Transform>().position;
        currentposition = GetComponent<Transform>().position;
        currentrotation = GetComponent<Transform>().rotation;
        camHorizontalPosition = cameraPosition.x;
        lastPlatformPosition = cameraPosition;
        lastPlatformPosition.y = lastPlatformPosition.y - 5f;
        lastPlatformPosition.z = player.transform.position.z;
    }

    void Update()
    {
        
    }
    
    //get current position and generate Platforms in limited range above
    private void FixedUpdate()
    {
        var height = currentposition.y;
        if (lastPlatformPosition.y <= height + 100f)
        {
            BoxCollider2D Platforms;
            Vector3 newPlatformPosition = NewPlatform(lastPlatformPosition, horizontalRange, height);
            Platforms = Instantiate(platform1, newPlatformPosition , currentrotation) as BoxCollider2D;
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
