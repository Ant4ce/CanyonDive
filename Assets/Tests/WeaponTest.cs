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
        public IEnumerator InstantiatesGameObjectFromPrefabAndChecksComponents()
        {
         
           // Setting up camera for test scene
            var cam = new GameObject();
            cam.AddComponent(typeof(Camera));
            var camera = cam.GetComponent<Camera>();
            camera.backgroundColor = Color.blue;
            cam = GameObject.Instantiate(cam);
            
            
            var weaponPrefab = Resources.Load("Tests/WeaponTestPrefab");
            Assert.IsTrue((weaponPrefab != null), "WeaponPrefab is null, make sure it has a reference");
            var spawnWeapon = GameObject.Instantiate(weaponPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;

            
            var thrownProjectile = GameObject.FindWithTag("Weapon");
            Assert.IsTrue((thrownProjectile != null), "thrownProjectile is null, make sure it has a reference");

            yield return new WaitForSeconds(2f);
            Assert.NotNull(spawnWeapon.gameObject.GetComponentInChildren<WeaponCollision>(), "WeaponCollsion component is not on Prefab"); 
            Assert.NotNull(spawnWeapon.gameObject.GetComponentInChildren<Rigidbody2D>(),"Prefab does not have a Rigidbody2d");
            Assert.NotNull(spawnWeapon.gameObject.GetComponentInChildren<BoxCollider2D>(), "BoxCollider2D is not set as a compenent");
            Assert.NotNull(spawnWeapon.gameObject.GetComponentInChildren<SpriteRenderer>(), "Prefab does not have a Sprite");

        
            Assert.IsTrue(thrownProjectile.name == weaponPrefab.name + "(Clone)");
        }

        [TearDown]
        public void AfterAllTests()
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Weapon"))
                Object.Destroy(gameObject);
            
        }
    }
}
