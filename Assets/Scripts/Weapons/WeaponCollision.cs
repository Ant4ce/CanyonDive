using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    public GameObject player;
    public static Vector3 _weaponPosition;
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
            _weaponPosition = GetComponent<Transform>().position;

            Debug.Log("hit a collider");
            try
            {
                player.transform.position = this.transform.position;
            }
            catch
            {
                Debug.Log("can't change player position");
            }
            weaponTeleport.OnHitCoolDownReset = false;
            Destroy(gameObject);
        }
    }
}
