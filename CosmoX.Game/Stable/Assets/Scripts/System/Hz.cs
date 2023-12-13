using UnityEngine;
using TMPro;

public class Hz : MonoBehaviour
{
    public TextMeshProUGUI hzText;
    private float refreshRate;

    void Start()
    {
        refreshRate = Screen.currentResolution.refreshRate;
        hzText.text = " " + refreshRate.ToString() + " Hz";
    }
}
