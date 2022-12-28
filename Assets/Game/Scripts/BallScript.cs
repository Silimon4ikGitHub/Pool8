using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float stopSpeed = 0.1f;
    [SerializeField] private AudioSource ballSound;
    private Rigidbody rb;
    private float mySpeed;
    private float fieldY = -105;
    public bool isMoving;
    public bool isStriped;
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ballSound.gameObject.transform.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (transform.position.y < fieldY)
        {
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
    private void OnCollisionEnter(Collision collider) 
    {
        if (collider.gameObject.GetComponent<BallScript>())
        {
          ballSound.volume = mySpeed;
          ballSound.Play();
        }
    }
}
