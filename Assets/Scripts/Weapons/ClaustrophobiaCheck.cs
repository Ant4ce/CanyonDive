using UnityEngine;

public class ClaustrophobiaCheck : MonoBehaviour
{
    public LayerMask groundlayer;
    public bool insideCheck = false;

    void FixedUpdate()
    {
        Claustrophobia();
    }

    void Claustrophobia()
    {
        var weaponPosition = transform.position;
        float rayLength = 1.5f;
        RaycastHit2D hitLeft = Physics2D.Raycast(weaponPosition, Vector2.left, rayLength, groundlayer);
        RaycastHit2D hitRight = Physics2D.Raycast(weaponPosition, Vector2.right, rayLength, groundlayer);
        RaycastHit2D hitUp = Physics2D.Raycast(weaponPosition, Vector2.up, rayLength, groundlayer);
        RaycastHit2D hitDown = Physics2D.Raycast(weaponPosition, Vector2.down, rayLength, groundlayer);

        if (hitDown.collider == true && hitLeft.collider == true && hitRight.collider == true && hitUp.collider == true)
        {
            insideCheck = true;
        }
        else
        {
            insideCheck = false;
        }
    }
}
