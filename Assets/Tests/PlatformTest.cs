using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class PlatformTest
    {
        private GameObject testCamera;
        private GameObject testPlayer;

        [SetUp]
        public void Setup()
        {
            SceneManager.CreateScene("TestScene");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestScene"));
            testCamera = new GameObject();
            testPlayer = new GameObject();
           
            testCamera.AddComponent<Camera>();
            testCamera.AddComponent<CameraFollow>();
            testCamera.AddComponent<PlatformGen>();
            
            testCamera.GetComponent<PlatformGen>().player = testPlayer;
            testCamera.GetComponent<CameraFollow>().player = testPlayer;
            testCamera.GetComponent<PlatformGen>().platformPrefab =
                Resources.Load<GameObject>("Tests/Testplatform");
            
            testCamera.transform.position = testPlayer.transform.position;
        }
        
        [TearDown]
        public void TearDown()
        {
            SceneManager.UnloadScene("TestScene");
        }

        [UnityTest]
        public IEnumerator TestPlatformSpawns()
        {
            var onePlatform = GameObject.FindWithTag("Platform");
            Assert.AreEqual(testCamera.GetComponent<PlatformGen>().platformPrefab.name + "(Clone)",
                onePlatform.name, "No instantiated Platforms were found");
            Assert.IsNotNull(onePlatform.GetComponent<PlatformDestruct>(), "Platform Objects contain no Destructor");
            yield break;
        }

        [UnityTest]
        public IEnumerator TestSpawnBoundaries()
        {
            var oldHighestPlatform = 0f;
            var oldPlayerHeight = testPlayer.transform.position.y;
            oldHighestPlatform = GetHighestPlatform(oldHighestPlatform);
            testPlayer.transform.position += Vector3.up * 5;
            yield return new WaitForSeconds(1f);
            var newHighest = GetHighestPlatform(oldHighestPlatform);
            Assert.IsTrue(testPlayer.transform.position.y > oldPlayerHeight, "testPlayer-Object did not move up");
            Assert.IsTrue(newHighest > oldHighestPlatform, "no new Platforms were created after Player moving up");
            Assert.IsTrue(CheckPlatformHorizontalBoundaries(), "Platforms spawn horizontally out of Camera vision");
            yield break;
        }

        [UnityTest]
        public IEnumerator TestPlatformDestruction()
        {
            testPlayer.transform.position += Vector3.up * 50f;
            var screenheight = testCamera.GetComponent<Camera>().orthographicSize;
            yield return new WaitForSeconds(1.5f);
            
            foreach (var Platform in GameObject.FindGameObjectsWithTag("Platform"))
            {
                Assert.IsTrue(Platform.transform.position.y > testPlayer.transform.position.y - screenheight, "Platforms don't get destroyed");
            }

            yield break;
        }

        private static float GetHighestPlatform(float highestPlatformHeight)
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Platform"))
            {
                highestPlatformHeight = Mathf.Max(gameObject.transform.position.y, highestPlatformHeight);
            }
            return highestPlatformHeight;
        }

        private bool CheckPlatformHorizontalBoundaries()
        {
            foreach (var Platform in GameObject.FindGameObjectsWithTag("Platform"))
            {
                var horizontalCameraSize = testCamera.GetComponent<Camera>().aspect * testCamera.GetComponent<Camera>().orthographicSize;
                var platformPosition = Platform.transform.position;
                var cameraPosition = testCamera.transform.position;
                
                if (platformPosition.x > cameraPosition.x + horizontalCameraSize && 
                    platformPosition.x < cameraPosition.x - horizontalCameraSize)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
