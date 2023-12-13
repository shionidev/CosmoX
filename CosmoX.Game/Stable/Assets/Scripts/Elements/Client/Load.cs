using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Load : MonoBehaviour
{
    public GameObject loadingUI;
    public GameObject errorUI;
    public string urlToLoad = "https://example.com"; // URL of the webpage to load

    private void Start()
    {
        loadingUI.SetActive(true);
        errorUI.SetActive(false);

        // Start the coroutine to load the webpage with updates every 5 seconds
        StartCoroutine(LoadWebPageWithUpdates());
    }

    private IEnumerator LoadWebPageWithUpdates()
    {
        yield return new WaitForSeconds(4.5f); // Initial delay of 4.5 seconds

        while (true)
        {
            // Log a message indicating that it's still loading
            Debug.Log("Still loading...");

            using (UnityWebRequest www = UnityWebRequest.Get(urlToLoad))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    // Webpage loaded successfully
                    Debug.Log("Webpage loaded successfully.");
                    loadingUI.SetActive(false);
                    break; // Break the loop once the webpage is loaded
                }
                else
                {
                    // Error loading webpage
                    Debug.LogError("Error loading webpage: " + www.error);
                    errorUI.SetActive(true);
                    break; // Break the loop on error
                }
            }

            yield return new WaitForSeconds(5f); // Wait for 5 seconds before checking again
        }
    }
}
