using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    [Range(0f, 10f)]
    private float _speed = 2.0f;

    private void FixedUpdate()
    {
        SmoothStalk();
    }
    // method that follows the player but doesnt snap to player instantly, rather it catches up
    void SmoothStalk()
    {
        // multiply by deltatime to make sure it is independant of frame rate
        float interpolation = _speed * Time.deltaTime;
        Vector3 targetPosition = this.transform.position;
        //Mathf.Max is used here to ensure that the lerp only can follow the player up not down. 
        targetPosition.y = Mathf.Lerp(this.transform.position.y, Mathf.Max(player.transform.position.y, this.transform.position.y), interpolation);
        this.transform.position = targetPosition;
    }
}
