using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D body;
   // private GameObject weapon = GameObject.Find("");
    public GameObject player;
    public GameObject weaponPrefab;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.bodyType = RigidbodyType2D.Dynamic;
        player = GameObject.Find("Bird");
        weaponTeleport.onHitCoolDown = true;
<<<<<<< HEAD:Assets/Scripts/Weapons/WeaponCollision.cs
        Debug.Log(weaponTeleport.onHitCoolDown);
=======
        //Debug.Log(weaponTeleport.onHitCoolDown);
>>>>>>> Sprites_Update:Assets/Scripts/Weapons/WeaponCollision.cs

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //If the GameObject, which in this case is a projectile, collides with an object it becomes sticky
    void OnCollisionEnter2D(Collision2D col)
    {
        
<<<<<<< HEAD:Assets/Scripts/Weapons/WeaponCollision.cs
        Debug.Log("Collision");
=======
        //Debug.Log("Collision");
>>>>>>> Sprites_Update:Assets/Scripts/Weapons/WeaponCollision.cs
        body.bodyType = RigidbodyType2D.Static;

        if (col.collider.tag == "PlatformsTag")
        {
            player.transform.position = this.transform.position;
            weaponTeleport.onHitCoolDown = false;
<<<<<<< HEAD:Assets/Scripts/Weapons/WeaponCollision.cs
            Debug.Log(weaponTeleport.onHitCoolDown);
=======
            //Debug.Log(weaponTeleport.onHitCoolDown);
>>>>>>> Sprites_Update:Assets/Scripts/Weapons/WeaponCollision.cs
            Destroy(gameObject);
        }
        //else if (col.gameObject.tag = "Enemy")
        //{
        //    
        //}
    }
}
