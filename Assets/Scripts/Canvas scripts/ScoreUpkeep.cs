using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpkeep : MonoBehaviour
{   
    // variable to save starting height, used for score calculation
    private float startingheight;
    Text score;
    // making the GameObject variable so it can be assigned the bird prefab in unity UI 
    public GameObject BirdToFollow;

    
    
    void Start()
    {  
        score = GetComponent<Text> ();
        // saving the starting height of the bird before the update method starts looping
        startingheight = BirdToFollow.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Mathf.floor is used to round down to the largest whole number so that we dont see all the decimal numbers
        score.text = "Score: " + Mathf.Floor(BirdToFollow.transform.position.y - startingheight);
    }
}
