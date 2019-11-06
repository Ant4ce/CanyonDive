using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpSc : MonoBehaviour
{
    private Rigidbody2D rbjp;
    public LayerMask groundlayer;
    //public float jumpTakeOffSpeed = 7;
    public float wallJumpStrength = 4;
    Vector2 vec2wr = new Vector2(-1, 1);

    // Start is called before the first frame update
    void Awake()
    {
        rbjp = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Jumper();
    }

    void Jumper()
    {
        //creating 3 rays, one down, one left and one right. Each of length 0.5f
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1.5f, groundlayer);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundlayer);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1.5f, groundlayer);

        //checks the appropriate rays to see whether conditions for a wall jump are met and if so makes the wall jump happen

        if ((hitleft.collider != null) && Input.GetButtonDown("Jump2") && (hitdown.collider == null))
        {
            rbjp.AddForce(Vector2.one * wallJumpStrength * 10);
        }
        else if ((hitright.collider != null) && Input.GetButtonDown("Jump2") && (hitdown.collider == null))
        {
            rbjp.AddForce(vec2wr * wallJumpStrength * 10);
        }
    }
}
