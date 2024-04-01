using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Interact : MonoBehaviour
{

    public GameObject UI;

    public string Test { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void Open()
    {
        UI.SetActive(true);
    }
    public void Close()
    {
        UI.SetActive(false);
    }
    public void ButtonClickedLog()
    {
        Debug.Log("Button Clicked!");
        Debug.Log("Checking for updates...");
        Debug.Log("Laoding User Interface File...");
    }
    public void RefreshClickedLog()
    {
        Debug.Log("Checking skin files...");
        Debug.Log("Laoding Interface...");
        Debug.Log("Assets Refreshed!");
    }
    public void SearchClickedLog()
    {
        Debug.Log("Searching...");
        Debug.Log("Done! Here's the result that we found");
    }
    public void InterfaceCloseLog()
    {
        Debug.Log("Closed...");
    }
    public void ExportDefaultLockedLog()
    {
        Debug.LogError("Error occurred!");
        Debug.LogError("Failed to export the selected skins...");
    }
        public void PreviewDefaultLockedLog()
    {
        Debug.LogError("Error occurred!");
        Debug.LogError("Something went wrong with the preview system. Please try again later...");
    }
}