using UnityEngine;
using UnityEngine.UI;

namespace ScoreUpkeeper
{
    public class ScoreUpkeep : MonoBehaviour
    {
        public GameObject player;

        private float _startingHeight;
        private float _actualHeight;
        Text scoreText;

        void Start()
        {
            scoreText = GetComponent<Text>();
            _startingHeight = player.transform.position.y;
        }

        void Update()
        {
            _actualHeight = player.transform.position.y;
            scoreText.text = "Score: " + ScoreCalculating.CalculatScore(_actualHeight, _startingHeight);
        }

    }
    public class ScoreCalculating
    {
        //Calculates score based on height gained since start
        public static float CalculatScore(float currentHeight, float startingHeight)
        {
            // Mathf.floor is used to round down to the largest whole number
            float score = Mathf.Floor(currentHeight - startingHeight);
            return score;
        }
    }
}