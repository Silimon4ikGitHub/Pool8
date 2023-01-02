using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
  private LineRenderer _lineRendererComponent;

    void Start()
    {
        _lineRendererComponent = GetComponent<LineRenderer>();
    }

    public void ShowTraectory(Vector3 origin, Vector3 lineDirrection)
    {
        Vector3[] points = new Vector3[10];
        _lineRendererComponent.positionCount = points.Length;
        
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            
            points[i] = origin + lineDirrection * time * time/2f;

            if (points[i].y < -100)
            {
                _lineRendererComponent.positionCount = i;
                break;
            }
        }
        _lineRendererComponent.SetPositions(points);

    }
}
