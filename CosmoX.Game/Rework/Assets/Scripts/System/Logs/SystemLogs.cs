using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Configuration;

public class SystemLogs : MonoBehaviour
{
    // Classic Information System Logs
    public void IsClicked()
    {
        Debug.Log("Button Clicked!");
        Debug.Log("Click Registered...");
    }

    public void IsSearching()
    {
        Debug.Log("Searching for results...");
    }

    public void IsFound()
    {
        Debug.Log("Results Found");
        Debug.Log("Showing Results to the player...");
    }

    public void IsExiting()
    {
        Debug.Log("Exiting the Game Client");
        Debug.Log("Disconnected from the server...");
    }

    public void IsConnecting()
    {
        Debug.Log("Connecting Player to the Server...");
        Debug.Log("Getting server connection...");
    }

    public void IsConnected()
    {
        Debug.Log("Player has successfuly connected to the server");
    }

    public void IsRefreshing()
    {
        Debug.Log("Starting Refreshing...");
        Debug.Log("This might take a while to process!");
    }

    public void IsRefreshed()
    {
        Debug.Log("The skin has been refreshed...");
        Debug.Log("?/01o");
    }

    // Warning Information System Logs

    // Error Information System Logs

    public void OnFailedToConnect()
    {
        Debug.LogError("Failed to connect to the server");
    }
}
