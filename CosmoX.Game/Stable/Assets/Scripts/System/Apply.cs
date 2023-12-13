using UnityEngine;
using UnityEngine.UI;

public class Apply : MonoBehaviour
{
    public GameObject uiElement; // The UI element you want to open/close
    public float duration = 2f; // The duration for which the UI element will be open

    private bool isOpen = false; // Tracks whether the UI element is currently open
    private float timer = 0f; // Tracks the time since the UI element was opened

    private void Update()
    {
        // If the UI element is currently open and the timer has exceeded the duration, close it
        if (isOpen && timer >= duration)
        {
            CloseUI();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void OpenUI()
    {
        uiElement.SetActive(true); // Show the UI element
        isOpen = true;
        timer = 0f;
    }

    private void CloseUI()
    {
        uiElement.SetActive(false); // Hide the UI element
        isOpen = false;
        timer = 0f;
    }
}
