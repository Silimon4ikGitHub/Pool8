using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CueScript : MonoBehaviour
{
   [SerializeField] private Vector3 mousePos;
   [SerializeField] private Rigidbody rb;
   [SerializeField] private float  angle;
   [SerializeField] private float  force;
   private float fieldY = -105;
   
   void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
   void Update()
   {
    RotateOnMouse();
    if (Input.GetKeyDown("space"))
    {
        rb.AddForce(-mousePos * force);
    }
    WhiteBallFall();
   }
   void RotateOnMouse()
   {
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    angle = Mathf.Atan2(-mousePos.x, -mousePos.z) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, angle, 0f);
   }
   void OnMouseDown()
    {
       rb.AddForce(Vector3.right * force);
    }
    
    void WhiteBallFall()
    {
        if (transform.position.y < fieldY)
        {
            SceneManager.LoadScene(0);
        }
    }

}
