using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,4 + Mathf.PingPong(Time.time *3, 4), transform.position.z);
    }
}
