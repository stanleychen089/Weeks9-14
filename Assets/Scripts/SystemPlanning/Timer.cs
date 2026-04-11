using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bestTimeDisplay;
    public float time = 0;
    public bool isFinished = false;
    public float bestTime = 10000000;
    public Transform duckisaur;
    public SpriteRenderer finishLineSR;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText.text = time.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is inside the finishline's SR, then they are finished
        //if they are finished, and the current timer is shorter than the best time, update the best time to time
        //update time to UI text
        if (finishLineSR.bounds.Contains(duckisaur.position))
        {
            isFinished = true;
            if (time < bestTime)
            {
                bestTime = time;
                bestTimeDisplay.text = bestTime.ToString("F2");
            }
        }
        //if the player has not finished, the time will increase and constantly update the text UI
        if (!isFinished)
        {
            time += Time.deltaTime;
            timerText.text = time.ToString("F2");
        }
        
    }

    public void restartTimer()
    {
        isFinished = false; 
        time = 0;
        timerText.text = time.ToString("F2");
    }
}
