using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CueScript : MonoBehaviour
{
   [SerializeField] private Vector3 mousePos;
   [SerializeField] private Vector3 mousePosition;
   [SerializeField] private Vector3 cuePosition;
   [SerializeField] private float cueSpeed;
   [SerializeField] private float cueOffsetLimit;
   [SerializeField] private Rigidbody rb;
   [SerializeField] private GameObject cue;
   [SerializeField] private ColorBallsScript colorBallScript;
   [SerializeField] private float  angle;
   [SerializeField] private float  force;
   [SerializeField] private Vector3  offsetY;
   private float fieldY = -105;
   
   void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
   void Update()
   {
    cuePosition = transform.position;

    WhiteBallFall();

    if (colorBallScript.areAllBallsStop)
       {
        
        RotateOnMouse();
        AddForceOnMouseDown();
        
        
        cue.SetActive(true);
       }
       else
       {
        cue.SetActive(false);
       }
    
   }
   void RotateOnMouse()
   {
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    angle = Mathf.Atan2(-mousePos.x, -mousePos.z) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, angle, 0f);
   }
    
    void WhiteBallFall()
    {
        if (transform.position.y < fieldY)
        {
            SceneManager.LoadScene(0);
        }
    }

    void AddForceOnMouseDown()
    {
        
        if(Input.GetKey(KeyCode.Mouse0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - offsetY);
            cue.transform.position = transform.position + Vector3.ClampMagnitude(mousePosition - transform.position, cueOffsetLimit);
            Cursor.visible = false;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            var dirrectionOfForce = new Vector3 (-mousePos.x, 0, -mousePos.z);
            rb.AddForce(dirrectionOfForce * force, ForceMode.Impulse);
            cue.SetActive(false);
            cue.transform.position = cuePosition;
            Cursor.visible = true;
        }
    }
  

}
