using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace Tests
{

    public class TeleportTest
    {
        private GameObject _cam;
        private GameObject _player;
        private GameObject _weapon;
        private GameObject _wall;
        private Rigidbody2D _weaponRigidBody;
        private Rigidbody2D playerRigidBody;


        [SetUp]
        public void SetUp()
        {
            
            _cam = GameObject.Instantiate(new GameObject());
            _cam.AddComponent(typeof(Camera));
            var camera = _cam.GetComponent<Camera>();
            camera.backgroundColor = Color.red;
            
            _player = GameObject.Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
            _player.AddComponent(typeof(Rigidbody2D));
            _player.AddComponent(typeof(BoxCollider2D));
            _player.name = "Bird";
            playerRigidBody = _player.GetComponent<Rigidbody2D>();
            playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            playerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
            _player.GetComponent<BoxCollider2D>().size = new Vector2(1f, 0.5f);

            



            _weapon = GameObject.Instantiate(new GameObject(), new Vector3(2, 0, 0), Quaternion.identity);
            _weapon.AddComponent(typeof(BoxCollider2D));
            _weapon.AddComponent(typeof(Rigidbody2D));
            _weapon.AddComponent(typeof(WeaponCollision));
            _weaponRigidBody = _weapon.GetComponent<Rigidbody2D>();
            _weaponRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            _weaponRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
            _weaponRigidBody.bodyType = RigidbodyType2D.Kinematic;
            _weapon.GetComponent<BoxCollider2D>().size = new Vector2(1f, 0.5f);



            _wall = GameObject.Instantiate(new GameObject(), new Vector3(6, 0, 0), Quaternion.identity);
            _wall.tag = "PlatformsTag";
            _wall.AddComponent(typeof(BoxCollider2D));
            
        }
        // A Test behaves as an ordinary method
        [Test]
        public void TeleportComponentTest()
        {
            Assert.NotNull(_player.gameObject.GetComponent<Rigidbody2D>(), "RigidBody2D component is not on any player Object");
            Assert.NotNull(_player.gameObject.GetComponent<BoxCollider2D>(), "BoxCollider2d component is not on any player Object");
            Assert.NotNull(_weapon.gameObject.GetComponent<BoxCollider2D>(), "BoxCollider2D component is not on any weapon Object");
            Assert.NotNull(_weapon.gameObject.GetComponent<Rigidbody2D>(), "RigidBody2D component is not on any weapon Object");
            Assert.NotNull(_weapon.gameObject.GetComponent<WeaponCollision>(), "WeaponCollision script is not on any weapon Object");
        }

        [Test]
        public void CameraComponentTest()
        {
            Assert.NotNull(_cam.gameObject.GetComponent<Camera>(), "Camera Object does not exist or cannot be found");
        }

   
        [UnityTest]
        public IEnumerator TeleportTestOfMovementAndCollision()
        {
            var weaponCollisionScript = _weapon.GetComponent<WeaponCollision>();
           // weaponCollisionScript.enabled = true;
                
            var playerPosition = _player.transform.position;
            var weaponPosition = _weapon.transform.position;
            _weaponRigidBody.velocity = new Vector3(3, 0, 0);
            Debug.Log(playerPosition);
            yield return new WaitForSeconds(3f);

            Vector3 newPlayerPosition = _player.transform.position;
            Vector3 newWeaponPosition = WeaponCollision._weaponPosition;
            Debug.Log(newWeaponPosition);
            //Assert.AreNotEqual(newPlayerPosition, playerPosition, "Player has moved");
            Assert.AreNotEqual(newWeaponPosition, weaponPosition, "Weapon has moved from");
            //Rounding up because unity returns 4.99... instead of 5, this way test runs properly
            Assert.AreEqual(Math.Ceiling(newWeaponPosition.x), _wall.transform.position.x - 1f, "Weapon has collided with wall and stuck to it");
        }

        [TearDown]
        public void AfterTeleportTests()
        {
            foreach (var gameObject in GameObject.FindObjectsOfType<GameObject>())
                Object.Destroy(_player);
                Object.Destroy(_weapon); 
                Object.Destroy(_wall);
                Object.Destroy(_cam);
       }
    }
}
