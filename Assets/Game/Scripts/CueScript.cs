using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CueScript : MonoBehaviour
{

   [SerializeField] private float cueSpeed;
   [SerializeField] private float cueOffsetLimit;
   [SerializeField] private float  force;
   [SerializeField] private Vector3  offsetY;
   [SerializeField] private GameObject cue;
   [SerializeField] private GameObject lineRenderer;
   [SerializeField] private ColorBallsScript colorBallScript;
   [SerializeField] private TrajectoryRenderer trajectoryScript;
   [SerializeField] private AudioSource shootSound;
    private float  angle;
    private float fieldY = -105;
    private Vector3 mousePos;
    private Vector3 mousePosition;
    private Vector3 cuePosition;
    private Vector3 dirrectionOfForce;
    private Vector3 lineDirrection;
    private Rigidbody myRB;
   
   void Awake()
    {
        myRB = gameObject.GetComponent<Rigidbody>();
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
            cue.transform.position = transform.position + Vector3.ClampMagnitude(mousePosition - transform.position * cueSpeed, cueOffsetLimit);
            lineRenderer.GetComponent<LineRenderer>().enabled = true;
            RenderBallLine();
            Cursor.visible = false;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            dirrectionOfForce = new Vector3 (-mousePos.x, 0, -mousePos.z);
            myRB.AddForce(dirrectionOfForce * force, ForceMode.Impulse);
            cue.SetActive(false);
            cue.transform.position = cuePosition;
            lineRenderer.GetComponent<LineRenderer>().enabled = false;
            Cursor.visible = true;
            shootSound.Play();
        }
    }
    void RenderBallLine()
    {
        lineDirrection = new Vector3(-mousePos.x * 100, transform.position.y, -mousePos.z * 100);
        trajectoryScript.ShowTraectory(transform.position, lineDirrection);
    }
}
