using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text score;
    public static int stripedScore;
    public static int colorScore;
    
    private void Update() 
    {
        score.text = stripedScore + "/" + colorScore;
    }
     private void OnTriggerEnter(Collider collision) 
     {
        if (collision.gameObject.GetComponent<BallScript>().isStriped)
        {
            stripedScore++;
        }
        if (!collision.gameObject.GetComponent<BallScript>().isStriped)
        {
            colorScore++;
        }
     }
}
