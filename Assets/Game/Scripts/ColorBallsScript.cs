using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallsScript : MonoBehaviour
{
    public GameObject[] balls;
    public bool areAllBallsStop;
    public int ballsOnTable;
    void Awake()
    {
        for (int i=0; i < balls.Length; i++)
        {
            balls[i] = transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        //CheckBallsMoution();
    }

    void CheckBallsMoution()
    {
        
        for (int i=0; i < balls.Length; i++)
        {
            if (balls[i] != null)
            {
             ballsOnTable++;
            //balls[i] = transform.GetChild(i).gameObject;
            //var _myArrayIndex = balls[i].GetComponent<BallScript>().myArrayIndex = i;
             if(!balls[i].GetComponent<BallScript>().isMoving)
             {
                areAllBallsStop = true;
             }
            }
            
        }
    }
}
