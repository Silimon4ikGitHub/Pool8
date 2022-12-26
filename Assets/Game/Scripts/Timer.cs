using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerString;
    [SerializeField] private double timerDouble = 3.0;
    [SerializeField] private double timerOffset = 0.01;

    private void FixedUpdate() 
    {
        timerString.text = timerDouble.ToString("F2");
        timerDouble -= Time.deltaTime * timerOffset;

        if (timerDouble < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
