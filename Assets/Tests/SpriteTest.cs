using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SpriteTest
    {
        
        // A Test behaves as an ordinary method
        [Test]
        public void PlayerComponentTestForAnimation()
        {

        }   

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SpriteTestWithEnumeratorPasses()
        {
            var playerPrefab = Resources.Load("Tests/PlayerTester");
            var testPlatform = Resources.Load("Tests/testerPlatform");
            Assert.IsTrue((playerPrefab) != null, "playerPrefab is not null");
            var player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity)as GameObject;
            var platformToStand = GameObject.Instantiate(testPlatform, new Vector3(0,-5,0), Quaternion.identity) as GameObject;
            Assert.NotNull(player.gameObject.GetComponent<Animator>().runtimeAnimatorController, "Is null for Animator");
            Assert.NotNull(player.gameObject.GetComponent<SpriteRenderer>(), "Is null for SpriteRenderer");
            Assert.NotNull(player.gameObject.GetComponent<SpriteRenderer>().sprite, "there is no sprite");

            Assert.NotNull(player.gameObject.GetComponent<WallJumpSc>(), "Is null for WallJump Script");
            Assert.NotNull(player.gameObject.GetComponent<Rigidbody2D>(), "Is null for RigidBody2D");

            var playerRigidBody = player.GetComponent<Rigidbody2D>();
            playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

            yield return new WaitForSeconds(0.4f);

            Assert.AreEqual( true, player.GetComponent<Animator>().GetBool("IsFalling"), "The IsFalling was false");

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(true, player.GetComponent<Animator>().GetBool("IsSteady"), "The IsSteady was false");

            yield return null;

        }
    }
}
