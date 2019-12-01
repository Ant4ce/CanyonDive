using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float playerspeed;
    private Rigidbody2D rb2d;
    private SpriteRenderer birdy;
    public float jumppower;
    Vector2 vec2up = new Vector2(0, 1);


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        birdy = GetComponent<SpriteRenderer>();
    }

    private void teleportmove()
    {
        rb2d.MovePosition(rb2d.position + vec2up * jumppower * Time.fixedDeltaTime );  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * playerspeed);

        if (Input.GetKeyDown("space"))
        {
            teleportmove();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "BirdFall")
        {
            GameManager.Instance.StartMenu();
        }
    }
}
