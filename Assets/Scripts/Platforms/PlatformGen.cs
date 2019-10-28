using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class PlatformGen : MonoBehaviour
{
    public BoxCollider2D platform1;
    public Rigidbody2D player;
    private Vector3 lastPlatformPosition;
    private float[] horizontalRange = {-2.5f, 2.5f};
    private float camHorizontalPosition;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 cameraPosition = GetComponent<Transform>().position;
        camHorizontalPosition = cameraPosition.x;
        lastPlatformPosition = cameraPosition;
        lastPlatformPosition.y = lastPlatformPosition.y - 5f;
        lastPlatformPosition.z = player.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var current = GetComponent<Transform>();
        if (lastPlatformPosition.y <= current.position.y + 100f)
        {
            BoxCollider2D Platforms;
            Vector3 newPlatformPosition = NewPlatform(lastPlatformPosition, horizontalRange);
            Platforms = Instantiate(platform1, newPlatformPosition , current.rotation) as BoxCollider2D;
        }
    }
    
    //This is the method defining the Platforms distance
    private Vector3 NewPlatform(Vector3 oldPlatform, float[] horizontalRange)
    {
        Vector3 newPlatform;
        newPlatform.x = camHorizontalPosition + Random.Range(horizontalRange[0],horizontalRange[1]);
        newPlatform.y = oldPlatform.y + 5f;
        newPlatform.z = oldPlatform.z;
        lastPlatformPosition = newPlatform;
        return newPlatform;
    }
}
