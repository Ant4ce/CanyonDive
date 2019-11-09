using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    //Public Section
    public GameObject marker;
    //Player Object
    public GameObject player;
    //Weapon Object - needed as reference to throw
    public GameObject weaponPrefab;
    public GameObject weaponStart;
    public GameObject wHolder;
    public GameObject heldWeapon;
    public float throwSpeed = 20.0f;
    public static bool onHitCoolDown = false;

    //Private Section
    private Vector3 target;
    private Vector2 startTouchPosition;
    private Vector3 draggingTouchPosition;
    private Vector3 endTouchPosition;
    private bool tap, swipe;
    void Start()
    {
        // Cursor.visible = false;
    }

    void Update()
    {
        tap = swipe = false;
        #region Standalone Inputs
        //Display mouse Position
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        //marker.transform.position = new Vector2(target.x, target.y );

        //Shows the difference between player and marker
        Vector3 difference = draggingTouchPosition - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        wHolder.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        
        
        if (Input.GetMouseButtonDown(0) && onHitCoolDown == false)
        {
            tap = true;
            startTouchPosition = Input.mousePosition;
            
           
            
        }
        else if (Input.GetMouseButton(0))
        { 
            draggingTouchPosition = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        }
        else if (Input.GetMouseButtonUp(0) && onHitCoolDown == false)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            throwSword(direction, rotationZ);
        }

        
        if (onHitCoolDown == false)
        {
            heldWeapon.SetActive(true);
        }
        else
        {
            heldWeapon.SetActive(false);
        }
        #endregion
        #region Mobile Input
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
            tap = true;
        }
        else if (Input.touchCount > 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch touch = Input.GetTouch(0);
            draggingTouchPosition = transform.GetComponent<Camera>()
                .ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, transform.position.z));
        }
        

        else if (Input.touchCount > 9 && Input.GetTouch(0).phase == TouchPhase.Ended && onHitCoolDown == false)
        {
            endTouchPosition = Input.GetTouch(0).position;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            throwSword(direction, rotationZ);
        }
        
        #endregion
        
        void throwSword(Vector2 direction, float rotation)
        {
            GameObject w = Instantiate(weaponPrefab) as GameObject;
            w.transform.position = weaponStart.transform.position;
            w.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            w.GetComponent<Rigidbody2D>().velocity = direction * throwSpeed;
            
            
        }
    }
}


