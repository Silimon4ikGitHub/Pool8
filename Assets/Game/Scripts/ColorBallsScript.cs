using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallsScript : MonoBehaviour
{
    [SerializeField] private WhiteBallScript whiteBallScript;
    public GameObject[] balls;
    public bool areAllBallsStop = true;

    void Awake()
    {
        for (int i=0; i < balls.Length; i++)
        {
            balls[i] = transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        CheckBallsMoution();
    }

    void CheckBallsMoution()
    {
       foreach (var item in balls)
       {
         if(item != null)
         {
           if (item.GetComponent<BallScript>().isMoving == true || whiteBallScript.isMoving == true)
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
    }
}
