using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Toggle1 : MonoBehaviour
{
    public List<Toggle> togglesList;
    public List<GameObject> uiElementsList;

    private void Start()
    {
        // Set the initial state of the UI elements based on the saved toggle states
        for (int i = 0; i < uiElementsList.Count; i++)
        {
            Toggle toggle = togglesList[i];
            GameObject uiElement = uiElementsList[i];

            // Load the saved toggle state
            string filePath = Application.persistentDataPath + "/toggleState" + i + ".dat";
            if (File.Exists(filePath))
            {
                string toggleState = File.ReadAllText(filePath);
                toggle.isOn = bool.Parse(toggleState);
            }

            // Set the active state of the UI element based on the toggle state
            uiElement.SetActive(toggle.isOn);

            // Add an event listener to the toggle
            toggle.onValueChanged.AddListener(delegate { ToggleUIElement(uiElement, toggle, i); });
        }
    }

    // Method that is called when a toggle is changed
    void ToggleUIElement(GameObject uiElement, Toggle toggle, int toggleIndex)
    {
        // Set the active state of the UI element based on the toggle state
        uiElement.SetActive(toggle.isOn);

        // Save the toggle state
        string filePath = Path.Combine(Application.persistentDataPath, "toggleState" + toggleIndex + ".dat");
        Debug.Log("Toggle state file path: " + filePath);
        File.WriteAllText(filePath, toggle.isOn.ToString());
        Debug.Log("Toggle state saved to file: " + toggle.isOn.ToString());
        Debug.Log("Toggle state file exists: " + File.Exists(filePath));
    }
}
