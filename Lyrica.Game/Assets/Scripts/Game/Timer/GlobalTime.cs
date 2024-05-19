using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GlobalTime : MonoBehaviour
{
    public GameObject Display;
    public int hour;
    public int minutes;
    public int seconds;

    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;

        string formattedHour = hour.ToString("D2");
        string formattedMinutes = minutes.ToString("D2");
        string formattedSeconds = seconds.ToString("D2");

        Display.GetComponent<TMP_Text>().text = formattedHour + ":" + formattedMinutes + ":" + formattedSeconds;
    }
}
