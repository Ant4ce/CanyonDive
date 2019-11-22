using UnityEngine;

public class ShardFloat : MonoBehaviour
{
    //makes the shard move up and down in menu
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, 4 + Mathf.PingPong(Time.time *3, 4), transform.position.z);
    }
}
