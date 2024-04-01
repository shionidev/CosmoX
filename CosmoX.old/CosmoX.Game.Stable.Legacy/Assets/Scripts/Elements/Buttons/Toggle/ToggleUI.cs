using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    public Toggle toggle0;
    public Toggle toggle1;
    public List<GameObject> uiElementsList0;
    public List<GameObject> uiElementsList1;

    private void Start()
    {
        // Set the initial state of the UI elements to be inactive
        foreach (GameObject uiElement in uiElementsList0)
        {
            uiElement.SetActive(false);
        }
        foreach (GameObject uiElement in uiElementsList1)
        {
            uiElement.SetActive(false);
        }

        // Add event listeners to the toggles
        toggle0.onValueChanged.AddListener(delegate { ToggleUIElements(0); });
        toggle1.onValueChanged.AddListener(delegate { ToggleUIElements(1); });
    }

    // Method that is called when a toggle is changed
    void ToggleUIElements(int toggleIndex)
    {
        List<GameObject> uiElementsList;

        if (toggleIndex == 0)
        {
            uiElementsList = uiElementsList0;
        }
        else if (toggleIndex == 1)
        {
            uiElementsList = uiElementsList1;
        }
        else
        {
            return;
        }

        Toggle toggle = toggleIndex == 0 ? toggle0 : toggle1;

        // Set the active state of the UI elements based on the toggle state
        foreach (GameObject uiElement in uiElementsList)
        {
            uiElement.SetActive(toggle.isOn);
        }

        // Save the toggle state
        string toggleKey = "toggleState" + toggleIndex;
        PlayerPrefs.SetInt(toggleKey, toggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    // Method that is called to load the saved toggle state
    void LoadToggleState(int toggleIndex)
    {
        string toggleKey = "toggleState" + toggleIndex;
        int toggleState = PlayerPrefs.GetInt(toggleKey, 0);
        if (toggleIndex == 0)
        {
            toggle0.isOn = toggleState == 1;
        }
        else if (toggleIndex == 1)
        {
            toggle1.isOn = toggleState == 1;
        }
    }

    // Method that is called to load the saved toggle states
    void LoadToggleStates()
    {
        LoadToggleState(0);
        LoadToggleState(1);
    }

    private void OnEnable()
    {
        LoadToggleStates();
    }
}
