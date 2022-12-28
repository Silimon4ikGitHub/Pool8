using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallScript : MonoBehaviour
{
    [SerializeField] private float mySpeed;
    [SerializeField] private float stopSpeed = 0.1f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource ballSound;
    public bool isMoving;

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
    private void OnCollisionEnter(Collision collider) 
    {
        if (collider.gameObject.GetComponent<BallScript>())
        {
          ballSound.volume = mySpeed;
          ballSound.Play();
        }
    }
}
