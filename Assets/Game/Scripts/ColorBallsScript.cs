using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallsScript : MonoBehaviour
{
    public GameObject[] balls;
    public bool areAllBallsStop = true;
    public int stoppedBallsOnTable;
    void Awake()
    {
        for (int i=0; i < balls.Length; i++)
        {
            balls[i] = transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        CheckBallsMoution2();
    }

    void CheckBallsMoution2()
    {
       foreach (var item in balls)
       {
         if(item != null)
         {
           if (item.GetComponent<BallScript>().isMoving == true)
           {
            areAllBallsStop = false;
            break;
           }
           else
           {
            areAllBallsStop = true;
           }
         }
       }

       if(areAllBallsStop)
       {
        Debug.Log("here is working");
       } 
    }
}
