using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaustrophobiaCheck : MonoBehaviour
{
    private Rigidbody2D rbwp;
    public LayerMask groundlayer;
    public bool inside = false;

    // Start is called before the first frame update
    void Awake()
    {
        rbwp = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Claustrophobia();
    }

    void Claustrophobia()
    {
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1.5f, groundlayer);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundlayer);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1.5f, groundlayer);
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, 1.5f, groundlayer);

        //Debug.Log(hitleft);
        //Debug.Log(hitright);
        //Debug.Log(hitup);
        //Debug.Log(hitdown);

        //Debug.Log(inside);

        //Debug.DrawRay(transform.position, Vector2.up *100, Color.red);

        if (hitdown.collider != null && hitleft.collider != null && hitright.collider != null && hitup.collider != null)
        {
            //Debug.Log("inside");
            inside = true;
        }
        else
        {
            //Debug.Log("not inside");
            inside = false;
        }
    }
}
