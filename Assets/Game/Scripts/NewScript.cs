using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    private Rigidbody rb;
    public float force;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        
    }
    
    void OnMouseDown()
    {
       rb.AddForce(Vector3.right * force);
    }
}
