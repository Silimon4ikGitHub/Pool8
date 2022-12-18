using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallScript : MonoBehaviour
{
   [SerializeField] private Vector3 prevousPosition;
    [SerializeField] private float mySpeed;
    [SerializeField] private float stopSpeed = 0.1f;
    [SerializeField] private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
     CheckMySpeed();

        if (mySpeed < stopSpeed)
        {
            StopMoution();
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
    }
}
