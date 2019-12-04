using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MenuButtonTest
    {
        [UnityTest]
        public IEnumerator MenuButtonTestWithEnumeratorPasses()
        {
            var playButtonPrefab = Resources.Load("Tests/PlayButtonTest");

            var playButton = GameObject.Instantiate(playButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

            Assert.NotNull(playButton.gameObject.GetComponent<BoxCollider2D>(), "no box collider");
            Assert.NotNull(playButton.gameObject.GetComponent<SpriteRenderer>(), "no sprite renderer");
            Assert.NotNull(playButton.gameObject.GetComponent<SpriteRenderer>().sprite, "no sprite");


            yield return new WaitForSeconds(1f);

            Object.Destroy(playButton);



            yield return null;
        }
    }
}
