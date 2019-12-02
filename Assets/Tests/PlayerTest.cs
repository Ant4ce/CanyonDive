using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTest
    {
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator InstantiatesPlayerFromPrefab()
        {
            
            var playerPrefab = Resources.Load("Tests/PlayerTestPrefab");
            if (playerPrefab != null)
            {
                Debug.Log("Not null");
            }

            var spawnPlayer =
                GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            yield return new WaitForSeconds(2f);

        }
    }
}
