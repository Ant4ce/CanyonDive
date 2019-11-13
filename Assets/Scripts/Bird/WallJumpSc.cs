using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpSc : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rbjp;
    public LayerMask groundlayer;
    //public float jumpTakeOffSpeed = 7;
    public float wallJumpStrength = 4;
    Vector2 vec2wr = new Vector2(-1, 1);
    private SpriteRenderer spriterender;

    // Start is called before the first frame update
    void Awake()
    {
        rbjp = GetComponent<Rigidbody2D>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rbjp.velocity.y < 0)
        {
            FallingAnim();
        }else if (rbjp.velocity.y == 0)
        {
            IdleAnim();
        }else if (rbjp.velocity.y > 0)
        {
            GoingUp();
        }

        Jumper();
    }

    void Jumper()
    {
        //creating 3 rays, one down, one left and one right. Each of length 0.5f
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1.5f, groundlayer);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 2.1f, groundlayer);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1.3f, groundlayer);

        //checks the appropriate rays to see whether conditions for a wall jump are met and if so makes the wall jump happen

        if ((hitleft.collider != null) && Input.GetButtonDown("Jump2") && (hitdown.collider == null))
        {
            if (spriterender.flipX == true)
            {
                spriterender.flipX = false;
            }
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsJumping", true);
            rbjp.AddForce(Vector2.one * wallJumpStrength * 10);
        }
        else if ((hitright.collider != null) && Input.GetButtonDown("Jump2") && (hitdown.collider == null))
        {
            if (spriterender.flipX == false)
            {
                spriterender.flipX = true;
            }
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsJumping", true);
            rbjp.AddForce(vec2wr * wallJumpStrength * 10);
        }
    }

    private void FallingAnim()
    {
        animator.SetBool("IsSteady", false);
        animator.SetBool("IsFalling", true);
        animator.SetBool("IsJumping", false);
    }

    private void IdleAnim()
    {
        animator.SetBool("IsSteady", true);
        animator.SetBool("IsFalling", false);
        animator.SetBool("IsJumping", false);
    }

    private void GoingUp()
    {
        animator.SetBool("IsSteady", false);
        animator.SetBool("IsFalling", false);
    }
}
