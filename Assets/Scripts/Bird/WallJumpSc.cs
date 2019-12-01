using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpSc : MonoBehaviour
{
    public Animator animator;
    public LayerMask groundlayer;
    public float wallJumpStrength = 4;

    private SpriteRenderer spriterender;
    private Rigidbody2D rigidBodyJump;
    private Vector2 upLeftVector = new Vector2(-1, 1);

    // Start is called before the first frame update
    void Awake()
    {
        rigidBodyJump = GetComponent<Rigidbody2D>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var fallspeed = rigidBodyJump.velocity.y;
        ResetAnimation();
        if (fallspeed < 0)
        {
            FallingAnimation();
        }else if(fallspeed == 0)
        {
            IdleAnimation();
        }
        Jumper();
    }

    void Jumper()
    {
        var playerPosition = transform.position;
        //length of raycast determined through testing with sprite dimensions, to give accurate depiction
        RaycastHit2D raycastLeft = Physics2D.Raycast(playerPosition, Vector2.left, 1.5f, groundlayer);
        RaycastHit2D raycastDown = Physics2D.Raycast(playerPosition, Vector2.down, 2.1f, groundlayer);
        RaycastHit2D raycastRight = Physics2D.Raycast(playerPosition, Vector2.right, 1.3f, groundlayer);

        //checks the appropriate rays to see whether conditions for a wall jump are met and if so makes the wall jump happen

        if ((raycastLeft.collider != null) && Input.GetButtonDown("Jump2") && (raycastDown.collider == null))
        {   
            spriterender.flipX = false;
            JumpingAnimation();
            rigidBodyJump.AddForce(Vector2.one * wallJumpStrength * 10);
        }
        else if ((raycastRight.collider != null) && Input.GetButtonDown("Jump2") && (raycastDown.collider == null))
        {
            spriterender.flipX = true;
            JumpingAnimation();
            rigidBodyJump.AddForce(upLeftVector * wallJumpStrength * 10);
        }
    }

    private void FallingAnimation()
    {
        animator.SetBool("IsFalling", true);
        animator.GetBool("IsFalling");
    }

    private void IdleAnimation()
    {
        animator.SetBool("IsSteady", true);
    }

    private void JumpingAnimation()
    {
        animator.SetBool("IsJumping", true);
    }

    private void ResetAnimation()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);
        animator.SetBool("IsSteady", false);
    }
}
