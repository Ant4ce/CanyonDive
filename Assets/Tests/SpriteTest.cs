using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SpriteTest
    {
        [UnityTest]
        public IEnumerator SpriteAndPlayerTestPasses()
        {
            var playerPrefab = Resources.Load("Tests/PlayerTester");
            var testPlatform = Resources.Load("Tests/testerPlatform");

            var player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity)as GameObject;
            var platformToStand = GameObject.Instantiate(testPlatform, new Vector3(0,-5,0), Quaternion.identity) as GameObject;

            Assert.IsTrue((playerPrefab) != null, "playerPrefab is not null");

            //Checking that all the components for the player object are present
            Assert.NotNull(player.gameObject.GetComponent<Animator>().runtimeAnimatorController, "Is null for Animator");
            Assert.NotNull(player.gameObject.GetComponent<SpriteRenderer>(), "Is null for SpriteRenderer");
            Assert.NotNull(player.gameObject.GetComponent<SpriteRenderer>().sprite, "there is no sprite");
            Assert.NotNull(player.gameObject.GetComponent<WallJumpSc>(), "Is null for WallJump Script");
            Assert.NotNull(player.gameObject.GetComponent<Rigidbody2D>(), "Is null for RigidBody2D");

            var playerRigidBody = player.GetComponent<Rigidbody2D>();
            playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

            //Checking the correct sprites states of the IsFalling and IsSteady bool
            yield return new WaitForSeconds(0.4f);

            Assert.AreEqual( true, player.GetComponent<Animator>().GetBool("IsFalling"), "The IsFalling was false");

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(true, player.GetComponent<Animator>().GetBool("IsSteady"), "The IsSteady was false");

            yield return null;

        }
    }
}
