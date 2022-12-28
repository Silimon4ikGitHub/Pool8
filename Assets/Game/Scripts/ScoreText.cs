using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] AudioSource ballInHoleSound;
    public Text score;
    public static int stripedScore;
    public static int colorScore;
    
    private void Start() 
    {
        ballInHoleSound.gameObject.transform.GetComponent<AudioSource>();
    }
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
        ballInHoleSound.Play();
     }
}
