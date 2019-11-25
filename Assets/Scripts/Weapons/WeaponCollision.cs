using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D _weaponRigidBody;
    void Start()
    {
        _weaponRigidBody = GetComponent<Rigidbody2D>();
        _weaponRigidBody.bodyType = RigidbodyType2D.Dynamic;
        player = GameObject.Find("Bird");
        weaponTeleport.OnHitCoolDownReset = true;
    }

    //If the GameObject collides, changes RigidBodytype to static
    void OnCollisionEnter2D(Collision2D col)
    {
        _weaponRigidBody.bodyType = RigidbodyType2D.Static;

        if (col.collider.tag == "PlatformsTag")
        {
            player.transform.position = this.transform.position;
            weaponTeleport.OnHitCoolDownReset = false;
            Destroy(gameObject);
        }
    }
}
