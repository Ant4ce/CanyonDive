using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class ScoreTest
    {
        
        [Test]
        public void ScoreTestSimplePasses()
        {
            //var nameSpaceHolder = new ScoreUpkeeper();

            float Hend = Random.Range(0,1000);
            float Hstart = Random.Range(0,999);

            float expectedH = Mathf.Floor(Hend - Hstart);
            float foundH = ScoreUpkeeper.ScoreCalculating.CalculatScore(Hend, Hstart);

            Assert.That(foundH, Is.EqualTo(expectedH));
        }
    }
}
