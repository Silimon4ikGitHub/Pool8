using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private float fieldY = -105;
    void Update()
    {
        if (transform.position.y < fieldY)
        {
            Destroy(transform.gameObject);
        }
    }
}
