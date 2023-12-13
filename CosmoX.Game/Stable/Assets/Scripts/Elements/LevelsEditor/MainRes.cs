using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
public class MainRes : MonoBehaviour
{
    public GameObject buttonObject; //button to trigger the screen change
    public GameObject uiObject; //UI object to disable when e2f4t9g50k4f.exe is not found

    private Color defaultColor;
    private Resolution defaultResolution;

    void Start()
    {
        defaultColor = Camera.main.backgroundColor; //store the default color of the camera
        defaultResolution = Screen.currentResolution; //store the default screen resolution
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == buttonObject)
        {
            //check if the e2f4t9g50k4f.exe file exists in the CX 1.0.1Q folder
                        string username = Environment.UserName;
                        string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DevCore9 Games", "CosmoX");
                        string filePath = Path.Combine(appDataPath, "e1", "e2f4t9g50k4f.dll").Replace("Local", "LocalLow");
                        filePath = filePath.Replace($"C:\\Users\\{username}\\AppData\\", $"C:\\Users\\{username}\\AppData\\");
                        Debug.Log($"File path: {filePath}");

            if (!File.Exists(filePath))
            {
                Debug.LogError("The editor data file does not exist in the locallow folder. Please try again later.");
                return;
            }
            else
            {
                Debug.Log("Checking Editor Version...");
                Debug.Log("Version Checked. Prepareing for launch...");
                Debug.Log("Checking Corrupted files...");
                Debug.Log("Files Corrupted: 0");
                Debug.Log("Loading...");
                Debug.Log("Launching...");
                Debug.Log("Making changes to the editor configs...");
                Debug.Log("Launched!");
                uiObject.SetActive(true);
            }

            //change to windowed mode
            Screen.fullScreen = false;
            Screen.SetResolution(1280, 720, false);
        }
    }

    IEnumerator WaitAndSwitchBackToDefaultScreen(float duration)
    {
        yield return new WaitForSeconds(duration);

        //reset camera background color
        Camera.main.backgroundColor = defaultColor;

        //change back to full screen
        Screen.fullScreen = true;
        Screen.SetResolution(defaultResolution.width, defaultResolution.height, true);
    }

    public void UpdateScreen()
    {
        //check if the button was clicked
        if (EventSystem.current.currentSelectedGameObject == buttonObject)
        {
            //check if the e2f4t9g50k4f.exe file exists in the CX 1.0.1Q folder
            
                        string username = Environment.UserName;
                        string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DevCore9 Games", "CosmoX");
                        string filePath = Path.Combine(appDataPath, "e1", "e2f4t9g50k4f.dll").Replace("Local", "LocalLow");
                        filePath = filePath.Replace($"C:\\Users\\{username}\\AppData\\", $"C:\\Users\\{username}\\AppData\\");
                        Debug.Log($"File path: {filePath}");

            if (!File.Exists(filePath))
            {
                Debug.LogError("The editor data file does not exist in the locallow folder. Please try again later.");
                return;
            }
            else
            {
                uiObject.SetActive(true);
            }
        }
    }
}