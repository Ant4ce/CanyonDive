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
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //If the GameObject, which in this case is a projectile, collides with an object it becomes sticky
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");
        body.bodyType = RigidbodyType2D.Static;

        if (col.gameObject.name == "Platforms")
        {
            player.transform.position = this.transform.position;
            Destroy(gameObject);
        }
        //else if (col.gameObject.tag = "Enemy")
        //{
        //    
        //}
    }
}
