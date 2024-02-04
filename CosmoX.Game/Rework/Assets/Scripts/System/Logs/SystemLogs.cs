using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Configuration;
using JetBrains.Annotations;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Diagnostics.Eventing.Reader;
using RiptideNetworking;
using UnityEditor.Experimental.Rendering;
using System.Threading;

public class SystemLogs : MonoBehaviour
{
    public static class Logger
    {
        public static void Log(string message)
        {
            Debug.Log(message);
        }

        public static void LogFromMethod(MonoBehaviour script, string methodName)
        {
            if (script != null)
            {
                System.Reflection.MethodInfo method = script.GetType().GetMethod(methodName);
                if (method != null)
                {
                    method.Invoke(script, null);
                }
                else
                {
                    Debug.LogWarning($"Method '{methodName}' not found in script '{script.GetType().Name}'.");
                }
            }
            else
            {
                Debug.LogWarning("Script instance is null.");
            }
        }
    }

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

    public void IsCheckingVersion()
    {
        Debug.Log("Checking your client version");
    }

    public void IsUpToDate()
    {
        Debug.Log("Client version has been checked");
    }

    public void IsCopying()
    {
        Debug.Log("Copying...");
        Thread.Sleep(2000);
        Debug.Log("Copied!");
    }

    // Warning Information System Logs

    // Error Information System Logs

    public void OnFailedToConnect()
    {
        Debug.LogError("Failed to connect to the server");
    }
}
