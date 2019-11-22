using UnityEngine;
using UnityEngine.UI;

namespace ScoreUpkeeper
{
    public class ScoreUpkeep : MonoBehaviour
    {
        // variable to save starting height, used for score calculation
        private float startingHeight;
        private float actualHeight;
        Text scoreText;
        public GameObject player;

        void Start()
        {
            scoreText = GetComponent<Text>();
            startingHeight = player.transform.position.y;
        }

        void Update()
        {
            actualHeight = player.transform.position.y;
            scoreText.text = "Score: " + ScoreCalcing.ScoreCalculator(actualHeight, startingHeight);
        }

    }
    public class ScoreCalcing
    {
        public static float ScoreCalculator(float currentHeight, float startingHeight)
        {
            // Mathf.floor is used to round down to the largest whole number
            float score = Mathf.Floor(currentHeight - startingHeight);
            return score;
        }
    }
}