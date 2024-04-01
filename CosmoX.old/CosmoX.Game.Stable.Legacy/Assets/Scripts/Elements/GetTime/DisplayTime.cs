using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour {

    public GameObject theDisplay;
    public int hour;
    public int minutes;
    public int seconds;

    void Update() {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;

        // Format hour, minutes, and seconds to have leading zeros if needed
        string formattedHour = hour.ToString("D2");
        string formattedMinutes = minutes.ToString("D2");
        string formattedSeconds = seconds.ToString("D2");

        theDisplay.GetComponent<Text>().text = formattedHour + ":" + formattedMinutes + ":" + formattedSeconds;
    }
}