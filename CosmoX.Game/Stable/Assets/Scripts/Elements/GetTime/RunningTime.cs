using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningTime : MonoBehaviour
{
    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    void Update()
    {
        UpdateTimerUI();
    }

    // Call this on update
    public void UpdateTimerUI()
    {
        // Update timer values
        secondsCount += Time.deltaTime;

        // Calculate hours, minutes, and seconds
        int seconds = (int)secondsCount % 60;
        int minutes = (int)secondsCount / 60 % 60;
        int hours = (int)secondsCount / 3600;

        // Format the values to have leading zeros
        string formattedHour = hours.ToString("D2");
        string formattedMinutes = minutes.ToString("D2");
        string formattedSeconds = seconds.ToString("D2");

        timerText.text = "Running " + formattedHour + ":" + formattedMinutes + ":" + formattedSeconds;
    }
}
