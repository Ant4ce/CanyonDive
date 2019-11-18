using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WeaponTest
    {
        //Resources folder is not ideal. Works for current tests, but should be replaced so the files aren't loaded from the system. (Some kind of service system maybe)
        [UnityTest]
        public IEnumerator InstantiatesGameObjectFromPrefab()
        {
           // Setting up camera for test scene
            var cam = new GameObject();
            cam.AddComponent(typeof(Camera));
            var camera = cam.GetComponent<Camera>();
            camera.backgroundColor = Color.blue;
            cam = GameObject.Instantiate(cam);
            
            
            // var weaponPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Weapon");
            var weaponPrefab = Resources.Load("Tests/weapon");
            if (weaponPrefab != null)
            {
                Debug.Log("Not null");
            }
            var spawnWeapon = GameObject.Instantiate(weaponPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;

            
            var thrownProjectile = GameObject.FindWithTag("Weapon");
            if (thrownProjectile != null)
            {
                Debug.Log(thrownProjectile);
            }
            
            yield return new WaitForSeconds(2f);
            var collision = spawnWeapon.gameObject.GetComponentInChildren<weaponCollision>();
            var physics = spawnWeapon.gameObject.GetComponentInChildren<Rigidbody2D>();
            var collider = spawnWeapon.gameObject.GetComponentInChildren<BoxCollider2D>();
            var image = spawnWeapon.gameObject.GetComponentInChildren<SpriteRenderer>();

        
            //Assert.AreEqual(weaponPrefab, prefabOfThrownWeapon);
            //Assert.AreEqual(weaponSpawnPrefab, prefabOfWeaponSpawner);
            Assert.IsTrue(thrownProjectile.name == weaponPrefab.name + "(Clone)");
            Assert.IsTrue((collision != null));
            Assert.IsTrue((physics != null));
            Assert.IsTrue((collider != null));
            Assert.IsTrue((image != null));

        }

        [TearDown]
        public void AfterAllTests()
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Weapon"))
                Object.Destroy(gameObject);
            
        }
    }
}
