using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
  private LineRenderer lineRendererComponent;

    void Start()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
    }

    public void ShowTraectory(Vector3 origin, Vector3 lineDirrection)
    {
        Vector3[] points = new Vector3[10];
        lineRendererComponent.positionCount = points.Length;
        
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            
            points[i] = origin + lineDirrection * time * time/2f;

            if (points[i].y < -100)
            {
                lineRendererComponent.positionCount = i;
                break;
            }
        }
        lineRendererComponent.SetPositions(points);

    }
}
