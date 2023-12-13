using UnityEngine;
using UnityEngine.UI;

public class EnablePass : MonoBehaviour
{
    public Toggle toggle;
    public GameObject uiElementToShowHide;

    private void Start()
    {
        // Ensure the initial state of the UI element matches the toggle state
        UpdateUIVisibility();
    }

    public void ToggleValueChanged()
    {
        UpdateUIVisibility();
    }

    private void UpdateUIVisibility()
    {
        if (toggle.isOn)
        {
            uiElementToShowHide.SetActive(true);  // Show the UI element
        }
        else
        {
            uiElementToShowHide.SetActive(false); // Hide the UI element
        }
    }
}
