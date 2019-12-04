using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WallJumpTest
    {
        [UnityTest]
        public IEnumerator WallJumpTestWithEnumeratorPasses()
        {
            var playerPrefab = Resources.Load("Tests/PlayerTester");
            var testPlatformWall = Resources.Load("Tests/testerPlatform");

            var player = GameObject.Instantiate(playerPrefab, new Vector3(3f, 0, 0), Quaternion.identity) as GameObject;
            var player2 = GameObject.Instantiate(playerPrefab, new Vector3(0.5f, 0, 0), Quaternion.identity) as GameObject;
            var wallToJump = GameObject.Instantiate(testPlatformWall, new Vector3(2, 0, 0), Quaternion.Euler(0.0f,0.0f, 90f)) as GameObject;

            Assert.NotNull(player.gameObject.GetComponent<Animator>().runtimeAnimatorController, "Is null for Animator");
            Assert.NotNull(player.gameObject.GetComponent<SpriteRenderer>(), "Is null for SpriteRenderer");
            Assert.NotNull(player.gameObject.GetComponent<SpriteRenderer>().sprite, "there is no sprite");
            Assert.NotNull(player.gameObject.GetComponent<WallJumpSc>(), "Is null for WallJump Script");
            Assert.NotNull(player.gameObject.GetComponent<Rigidbody2D>(), "Is null for RigidBody2D");

            Assert.NotNull(player2.gameObject.GetComponent<Animator>().runtimeAnimatorController, "Is null for Animator");
            Assert.NotNull(player2.gameObject.GetComponent<SpriteRenderer>(), "Is null for SpriteRenderer");
            Assert.NotNull(player2.gameObject.GetComponent<SpriteRenderer>().sprite, "there is no sprite");
            Assert.NotNull(player2.gameObject.GetComponent<WallJumpSc>(), "Is null for WallJump Script");
            Assert.NotNull(player2.gameObject.GetComponent<Rigidbody2D>(), "Is null for RigidBody2D");

            WallJumpSc.WallJumpRight(player.GetComponent<Rigidbody2D>());
            WallJumpSc.WallJumpLeft(player2.GetComponent<Rigidbody2D>());
            player2.GetComponent<SpriteRenderer>().flipX = true;

            yield return new WaitForSeconds(0.2f);
            Assert.AreEqual(false, player.GetComponent<Animator>().GetBool("IsFalling"), "He is not jumping");
            Assert.AreEqual(false, player2.GetComponent<Animator>().GetBool("IsFalling"), "He is not jumping");
            yield return new WaitForSeconds(3f);
            Assert.AreEqual(true, player.GetComponent<Animator>().GetBool("IsFalling"), "He is not falling");
            Assert.AreEqual(true, player2.GetComponent<Animator>().GetBool("IsFalling"), "He is not falling");

            Object.Destroy(player);
            Object.Destroy(player2);
            Object.Destroy(wallToJump);
            yield return null;
        }
    }
}
