using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Vector3 prevousPosition;
    [SerializeField] private float mySpeed;
    [SerializeField] private float stopSpeed = 0.1f;
    [SerializeField] private Rigidbody rb;
    private float fieldY = -105;
    public bool isMoving;
    public int myArrayIndex;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (transform.position.y < fieldY)
        {
            GetComponentInParent<ColorBallsScript>().balls[myArrayIndex] = null;
            Destroy(transform.gameObject);
        }

     CheckMySpeed();

        if (mySpeed < stopSpeed)
        {
            StopMoution();
        }
        else
        {
            isMoving = true;
        }
    }

    void CheckMySpeed()
    {
        mySpeed = rb.velocity.magnitude;
    }
    
    void StopMoution()
    {
        rb.freezeRotation = true;
        rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.None;
        isMoving = false;
    }
}
