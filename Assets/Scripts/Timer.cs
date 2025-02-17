using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30;
    float ActiveTime = 30;
    public float[] LvlTimes = { 30f, 50f, 70f, 90f, 110f, 130f};
    public float PlayTime = 0;
    public bool timerIsRunning = false;
    public TMP_Text Textbox;
    WordGameBase Base;
    public static Timer instance;

    void Awake()
    {
        //sets up links to components and other objects
        Textbox = GetComponent<TextMeshProUGUI>();
        Base = FindObjectOfType<WordGameBase>();

        //this is a way to have to have a singleton without having to worry about static classes and conficts etc
        //Now any script that uses this doesn't need to specify anywhere which object it wants
        //It just needs to say, for example, "Timer.instance.TimerStop();"
        if (instance != null)
        {
            Debug.LogError("Found more than one Timer in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    void Update()
    {
        PlayTime += Time.deltaTime;
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayCountdown();
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                Base.Lose();
            }
        }
    }

    public void TimerStart()
    {
        timerIsRunning = true;
    }

    public void TimerStop()
    {
        timerIsRunning = false;
    }

    public string PlayTimeClock()
    {
        //converts playtime into minutes and seconds
        float PlayMinutes = Mathf.FloorToInt(PlayTime / 60);
        float PlaySeconds = Mathf.FloorToInt(PlayTime % 60);
        //turns minutes and seconds into 2-digit numbers and puts them in a MM:SS display
        return string.Format("{0:00}:{1:00}", PlayMinutes, PlaySeconds);
    }

    void DisplayCountdown()
    {
        float TimetoDisplay = timeRemaining + 1;
        TimetoDisplay = Mathf.FloorToInt(TimetoDisplay);
        Textbox.SetText(TimetoDisplay.ToString());
    }

    public void TimerReset()
    {
        timeRemaining = ActiveTime;
    }

    public void ChangeTimerLevel(int lvl)
    {
        ActiveTime = LvlTimes[lvl];
    }

    public void ResetPlayTime()
    {
        PlayTime = 0;
    }

}
