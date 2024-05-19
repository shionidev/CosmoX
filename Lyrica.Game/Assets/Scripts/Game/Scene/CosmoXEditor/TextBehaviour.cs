using UnityEngine;
using UnityEngine.UI;

public class TextBehaviour : MonoBehaviour
{
    public Text textComponent;

    void Start()
    {
        if (textComponent == null)
            textComponent = GetComponent<Text>();

        textComponent.text = "Rythmik Editor";

        string text = textComponent.text;

        int startIndexRythmik = text.IndexOf("Rythmik");
        int startIndexEditor = text.IndexOf(" Editor");

        string coloredText = "<color=white>" + text.Substring(startIndexRythmik, 7) + "</color>";
        coloredText += "<color=magenta>" + text.Substring(startIndexEditor, 7) + "</color>";

        textComponent.text = coloredText;
    }
}
