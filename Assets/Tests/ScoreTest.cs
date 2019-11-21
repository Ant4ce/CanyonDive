using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScoreTest
    {
        
        [Test]
        public void ScoreTestSimplePasses()
        {
            //var nameSpaceHolder = new ScoreUpkeeper();

            float Hend = 198;
            float Hstart = 34;

            float expectedH = Mathf.Floor(Hend - Hstart);
            float foundH = ScoreUpkeeper.ScoreCalcing.ScoreCalculator(Hend, Hstart);

            Assert.That(foundH, Is.EqualTo(expectedH));
        }
    }
}
