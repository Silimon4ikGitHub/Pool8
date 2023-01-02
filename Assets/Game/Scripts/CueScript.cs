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
    private float  _angle;
    private float _fieldY = -105;
    private Vector3 _mousePos;
    private Vector3 _mousePosition;
    private Vector3 _cuePosition;
    private Vector3 _dirrectionOfForce;
    private Vector3 _lineDirrection;
    private Rigidbody _myRB;
    private LineRenderer LineRendererScript;
   
   void Awake()
    {
        _myRB = gameObject.GetComponent<Rigidbody>();
        LineRendererScript = lineRenderer.GetComponent<LineRenderer>();
    }
   void Update()
   {
    _cuePosition = transform.position;

    CheckWhiteBallFall();

    if (colorBallScript.areAllBallsStop)
       {
        
        RotateCueByMouse();
        AddForceOnMouseDown();
        
        
        cue.SetActive(true);
       }
       else
       {
        cue.SetActive(false);
       }
    
   }
   void RotateCueByMouse()
   {
    _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    _angle = Mathf.Atan2(-_mousePos.x, -_mousePos.z) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, _angle, 0f);
   }
    
    void CheckWhiteBallFall()
    {
        if (transform.position.y < _fieldY)
        {
            SceneManager.LoadScene(0);
        }
    }

    void AddForceOnMouseDown()
    {
        
        if(Input.GetKey(KeyCode.Mouse0))
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - offsetY);
            cue.transform.position = transform.position + Vector3.ClampMagnitude(_mousePosition - transform.position * cueSpeed, cueOffsetLimit);
            LineRendererScript.enabled = true;
            RenderBallLine();
            Cursor.visible = false;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _dirrectionOfForce = new Vector3 (-_mousePos.x, 0, -_mousePos.z);
            _myRB.AddForce(_dirrectionOfForce * force, ForceMode.Impulse);
            cue.SetActive(false);
            cue.transform.position = _cuePosition;
            LineRendererScript.enabled = false;
            Cursor.visible = true;
            shootSound.Play();
        }
    }
    void RenderBallLine()
    {
        _lineDirrection = new Vector3(-_mousePos.x * 100, transform.position.y, -_mousePos.z * 100);
        trajectoryScript.ShowTraectory(transform.position, _lineDirrection);
    }
}
