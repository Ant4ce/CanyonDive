using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //variable to hold and update the y position of the player object
    private float playerHeight;
    private float _speedMultiplier = 1f;

    [SerializeField]
    [Range(0f,0.1f)]
    private float _acceleration = 0.005f;
    
    // calculates the speed of upwards motion by the camera at different heights
    void FixedUpdate()
    {
        playerHeight = transform.position.y;

        if (playerHeight < 100)
        {
            transform.Translate(Vector3.up * Time.deltaTime );
        }
        else
        {
            _speedMultiplier += _acceleration;
            transform.Translate(Vector3.up * Time.deltaTime * _speedMultiplier);
        }
    }
}
