using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponTeleport : MonoBehaviour
{
    //Need to create a Raycast that takes a mouseclick as input to determin the vector and have a velocity increase to that position
    // The player model then gets a linecast and changes position to the weapon position
    // Start is called before the first frame update
    //Cursor Object
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

    //Location of the Mouse
    private Vector3 target;
    void Start()
    {
        //hide Cursor
        Cursor.visible = false;
    }

    void Update()
    {
        //Display mouse Position and keep track of it
        //Uses camera as main Object to be independant from PlayerObject
        //Displays a cursor on mouse position and keeps trackk of the position
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        marker.transform.position = new Vector2(target.x, target.y );

        //Shows the difference between player and marker
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        wHolder.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        
        //if statement for left mouse button event
        //should take the difference and create a direction, calls throwSword method after calculating direction
        if (Input.GetMouseButtonDown(0) && onHitCoolDown == false)
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
        //should instantiate a Prefab and give it a velocity to the direction of the mouse cursor.
        void throwSword(Vector2 direction, float rotation)
        {
            GameObject w = Instantiate(weaponPrefab) as GameObject;
            w.transform.position = weaponStart.transform.position;
            w.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            w.GetComponent<Rigidbody2D>().velocity = direction * throwSpeed;
            
            
        }
    }
}
//Use WeaponPrefab as GameObject. Don't instantiate it. Instead give the normal one a velocity. Use it's vectors to establish a raycast direction
//When player position == Weapon position reset weapon position to the previous local scale
//Weapon can move in the direction aimed by adding rotation (see old tutorial)
// If collisionenter start timer or use player position to == object positin b4 destroying


// 1.Destoy Object       2. Teleport player to object          3.Put delay
