using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    //public Transform raycaster;
    public LayerMask groundlayer;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    private bool Groundcheck = false;
    public float wallJumpStrength = 4;

    Vector2 vec2wr = new Vector2(-1, 1);
    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
        
    //    Groundcheck = true;
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
        
    //    Groundcheck = false;
    //}
    //private void Update()
    //{
    //    //Debug.Log("Player position is: " + transform.position);
    //    ComputeVelocity();
    //}



    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        //creating 3 rays, one down, one left and one right. Each of length 0.5f
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 0.5f, groundlayer);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundlayer);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 0.5f, groundlayer);

        //checks the appropriate rays to see whether conditions for a wall jump are met and if so makes the wall jump happen

        if ((hitleft.collider != null) && Input.GetButtonDown("Jump") && (hitdown.collider == null))
        {
            rb.AddForce(Vector2.one * wallJumpStrength *10);
        }
        else if ((hitright.collider != null) && Input.GetButtonDown("Jump") && (hitdown.collider == null))
        {
            rb.AddForce(vec2wr * wallJumpStrength *10);
        }
        else if (Input.GetButtonDown("Jump") && (hitdown.collider != null))
        {

            velocity.y = jumpTakeOffSpeed;
            if (Input.GetButtonUp("Jump") && velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }

        }



        //if (Input.GetButtonDown("Jump") && Groundcheck)
        //{
        //    velocity.y = jumpTakeOffSpeed;
        //}
        //else if (Input.GetButtonUp("Jump"))
        //{
        //if (velocity.y > 0)
        //{
        //    velocity.y = velocity.y * 0.5f;
        //}
        //}




        if (move.x > 0.00f)
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (move.x < 0.00f)
        {
            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }

        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}