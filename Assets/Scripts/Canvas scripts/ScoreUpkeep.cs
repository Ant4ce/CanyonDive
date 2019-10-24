using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpkeep : MonoBehaviour
{
    private float startingheight;
    Text score;
    public GameObject BirdToFollow;
    private static int startheight = 1;


    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text> ();
        startingheight = BirdToFollow.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + Mathf.Floor(BirdToFollow.transform.position.y - startingheight);
    }
}
