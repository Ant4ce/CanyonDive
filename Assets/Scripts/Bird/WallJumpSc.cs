using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpSc : MonoBehaviour
{
<<<<<<< HEAD
=======
    public Animator animator;
>>>>>>> Sprites_Update
    private Rigidbody2D rbjp;
    public LayerMask groundlayer;
    //public float jumpTakeOffSpeed = 7;
    public float wallJumpStrength = 4;
    Vector2 vec2wr = new Vector2(-1, 1);
<<<<<<< HEAD
=======
    private SpriteRenderer spriterender;
>>>>>>> Sprites_Update

    // Start is called before the first frame update
    void Awake()
    {
        rbjp = GetComponent<Rigidbody2D>();
<<<<<<< HEAD

=======
        spriterender = GetComponent<SpriteRenderer>();
>>>>>>> Sprites_Update
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
=======
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

>>>>>>> Sprites_Update
        Jumper();
    }

    void Jumper()
    {
        //creating 3 rays, one down, one left and one right. Each of length 0.5f
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1.5f, groundlayer);
<<<<<<< HEAD
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundlayer);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1.5f, groundlayer);
=======
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 2.1f, groundlayer);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1.3f, groundlayer);
>>>>>>> Sprites_Update

        //checks the appropriate rays to see whether conditions for a wall jump are met and if so makes the wall jump happen

        if ((hitleft.collider != null) && Input.GetButtonDown("Jump2") && (hitdown.collider == null))
        {
<<<<<<< HEAD
=======
            if (spriterender.flipX == true)
            {
                spriterender.flipX = false;
            }
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsJumping", true);
>>>>>>> Sprites_Update
            rbjp.AddForce(Vector2.one * wallJumpStrength * 10);
        }
        else if ((hitright.collider != null) && Input.GetButtonDown("Jump2") && (hitdown.collider == null))
        {
<<<<<<< HEAD
            rbjp.AddForce(vec2wr * wallJumpStrength * 10);
        }
    }
=======
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
>>>>>>> Sprites_Update
}
