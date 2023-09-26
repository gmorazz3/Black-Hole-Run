using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimerScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    public float elapsedTime;
    // Update is called once per frame
    public void Start()
    {
        ResumeTimer();
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes =Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        
    }

    public void PauseTimer()
    {
        Time.timeScale = 0;
    }
    public void ResumeTimer()
    { 
        Time.timeScale = 1;
    }
    public void ResetTimer()
    {
        elapsedTime = 0;
    }
}
