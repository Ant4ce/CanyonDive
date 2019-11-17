using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TeleportTest
    {
        //REsources folder is not ideal. Works for current tests, but should be replaced so the files aren''t loaded from the system. (Some kind of service system maybe)
        [UnityTest]
        public IEnumerator TeleportInstantiatesGameObjectFromPrefab()
        {
            var weaponPrefab = Resources.Load("Tests/Weapon");
            var weaponSpawnPrefab = Resources.Load("Tests/weaponStart");
            
            var thrownProjectile = GameObject.FindWithTag("weapon");
            var throwStart = GameObject.FindWithTag("WeaponSpawn");
            var prefabOfThrownWeapon = PrefabUtility.GetPrefabParent(thrownProjectile);
            var prefabOfWeaponSpawner = PrefabUtility.GetPrefabParent(throwStart);
            
            Assert.AreEqual(weaponPrefab, prefabOfThrownWeapon);
            Assert.AreEqual(weaponSpawnPrefab, prefabOfWeaponSpawner);
            
            yield return null;
        }

        [TearDown]
        public void AfterAllTests()
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("weapon"))
                Object.Destroy(gameObject);
        }
    }
}
