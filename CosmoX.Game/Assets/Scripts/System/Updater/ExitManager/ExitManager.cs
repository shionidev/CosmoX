using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExitManager : MonoBehaviour
{
    public TMP_Text textComponent1;
    public TMP_Text textComponent2;
    public string newText1 = "New text to display";
    public string newText2 = "New text to display";

    void Update()
    {

        if (textComponent1 != null)
        {
            textComponent1.text = newText1;
        }

        if (textComponent2 != null)
        {
            textComponent2.text = newText2;
        }
    }
}