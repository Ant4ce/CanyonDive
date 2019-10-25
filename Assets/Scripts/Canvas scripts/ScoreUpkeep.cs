using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpkeep : MonoBehaviour
{   
    // variable to save starting height, used for score calculation
    private float startingheight;
    // variable to assign text to
    Text score;
    // making the GameObject variable so it can be assigned the bird prefab in unity UI 
    public GameObject BirdToFollow;

    // Start is called before the first frame update
    
    void Start()
    {
        // assigning the unity Text component to text variable "score"  
        score = GetComponent<Text> ();
        
        // saving the starting height of the bird before the update method starts looping
        startingheight = BirdToFollow.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // changing the content of score variable to "Score: " and calculating score based on y position of bird player - the starting height of the player
        // Mathf.floor is used to round down to the largest whole number so that we dont see all the decimal numbers
        score.text = "Score: " + Mathf.Floor(BirdToFollow.transform.position.y - startingheight);
    }
}
