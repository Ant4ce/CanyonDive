using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScoreUpkeeper
{
    public class ScoreUpkeep : MonoBehaviour
    {
        // variable to save starting height, used for score calculation
        private float startingheight;
        private float actualheight;
        Text score;
        // making the GameObject variable so it can be assigned the bird prefab in unity UI 
        public GameObject BirdToFollow;

        void Start()
        {
            score = GetComponent<Text>();
            // saving the starting height of the bird before the update method starts looping
            startingheight = BirdToFollow.transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            //ScoreCalcing calcMe = new ScoreCalcing();
            actualheight = BirdToFollow.transform.position.y;
            score.text = "Score: " + ScoreCalcing.ScoreCalculator(actualheight, startingheight);
        }

    }
    public class ScoreCalcing
    {
        public static float ScoreCalculator(float currentH, float startingH)
        {
            // Mathf.floor is used to round down to the largest whole number so that we dont see all the decimal numbers
            float finalH = Mathf.Floor(currentH - startingH);
            return finalH;
        }
    }
}