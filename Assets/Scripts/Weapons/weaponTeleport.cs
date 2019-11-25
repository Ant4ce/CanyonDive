using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponTeleport : MonoBehaviour
{
    public GameObject player;
    //Weapon Object - needed as reference to throw
    public GameObject weaponPrefab;
    public GameObject throwOriginPoint;
    public GameObject rotationAxisForWeapon;
    public GameObject heldWeapon;
    public float throwSpeed = 20.0f;
    public static bool OnHitCoolDownReset = false;
    
    private Vector3 _draggingTouchPosition;

    void Update()
    {
        #region Standalone Inputs
        //Shows the difference between player and cursor
        Vector3 difference = _draggingTouchPosition - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotationAxisForWeapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        
        if (Input.GetMouseButton(0))
        { 
            _draggingTouchPosition = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        }
        else if (Input.GetMouseButtonUp(0) && OnHitCoolDownReset == false)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            throwSword(direction, rotationZ);
        }
        #endregion

        if (OnHitCoolDownReset == false) { heldWeapon.SetActive(true); }else{ heldWeapon.SetActive(false); }
        #region Mobile Input
        
        if (Input.touchCount > 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch touch = Input.GetTouch(0);
            _draggingTouchPosition = transform.GetComponent<Camera>()
                .ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, transform.position.z));
        }
        

        else if (Input.touchCount > 9 && Input.GetTouch(0).phase == TouchPhase.Ended && OnHitCoolDownReset == false)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            throwSword(direction, rotationZ);
        }
        
        #endregion
    }
    private void throwSword(Vector2 direction, float rotation)
    {
        GameObject weaponInstance = Instantiate(weaponPrefab) as GameObject;
        weaponInstance.transform.position = throwOriginPoint.transform.position;
        weaponInstance.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation -90f);
        weaponInstance.GetComponent<Rigidbody2D>().velocity = direction * throwSpeed;
    }
}


