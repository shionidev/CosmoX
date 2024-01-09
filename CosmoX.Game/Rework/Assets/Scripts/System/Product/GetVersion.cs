using UnityEngine;
using TMPro;

public class GetVersion : MonoBehaviour
{
    private void Start()
    {
        string version = Application.version;
        TextMeshProUGUI tmpText = GetComponent<TextMeshProUGUI>();
        tmpText.text = "You're currently running " + version;
    }
}