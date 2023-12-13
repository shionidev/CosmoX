using System.Collections;
using UnityEngine;
using TMPro;

public class LoadUpdater : MonoBehaviour
{
    public TMP_Text textComponent;
    public GameObject Interface; // Reference to the loading UI GameObject

    private void Start()
    {
        if (textComponent == null)
        {
            Debug.LogError("TextMesh Pro text component not assigned!");
            return;
        }

        if (Interface != null)
            Interface.SetActive(false);

        StartCoroutine(ChangeTextWithDelays());
    }

    private IEnumerator ChangeTextWithDelays()
    {
        yield return new WaitForSeconds(0f);
        textComponent.text = "";

        yield return new WaitForSeconds(1f);
        textComponent.text = "Loading...";

        yield return new WaitForSeconds(1f);
        textComponent.text = "Initializing Scripts...";

        yield return new WaitForSeconds(1f);
        textComponent.text = "Configuring Updater...";

        yield return new WaitForSeconds(1f);
        textComponent.text = "";

        // Activate the loading UI GameObject after all text is displayed
        if (Interface != null)
            Interface.SetActive(true);
    }
}
