using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float stopSpeed = 0.1f;
    [SerializeField] private AudioSource ballSound;
    private float _mySpeed;
    private float _fieldY = -105;
    private Rigidbody _rb;
    public bool isMoving;
    public bool isStriped;
    
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        ballSound.gameObject.transform.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (transform.position.y < _fieldY)
        {
            Destroy(transform.gameObject);
        }

     CheckMySpeed();

        if (_mySpeed < stopSpeed)
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
        _mySpeed = _rb.velocity.magnitude;
    }
    
    void StopMoution()
    {
        _rb.freezeRotation = true;
        _rb.freezeRotation = false;
        _rb.constraints = RigidbodyConstraints.FreezePosition;
        _rb.constraints = RigidbodyConstraints.None;
        isMoving = false;
    }
    private void OnCollisionEnter(Collision collider) 
    {
        if (collider.gameObject.GetComponent<BallScript>())
        {
          ballSound.volume = _mySpeed;
          ballSound.Play();
        }
    }
}
