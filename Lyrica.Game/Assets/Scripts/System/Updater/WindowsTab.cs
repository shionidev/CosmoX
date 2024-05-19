using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowsTab : MonoBehaviour
{
    public TMP_Text textComponent1;
    public TMP_Text textComponent2;
    public string newText = "New text to display";

    void Update()
    {
        
        if (textComponent1 != null)
        {
            textComponent1.text = newText;
        }

        if (textComponent2 != null)
        {
            textComponent2.text = newText;
        }
    }
}
