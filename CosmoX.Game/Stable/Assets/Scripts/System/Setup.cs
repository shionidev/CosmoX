using System.IO;
using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Collections;
using System.IO.Compression;

public class Setup : MonoBehaviour
{
    void Start()
    {
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "..", "LocalLow", "DevCore9 Games", "CosmoX");

        if (!Directory.Exists(Path.Combine(folderPath, "Levels")))
        {
            Directory.CreateDirectory(Path.Combine(folderPath, "Levels"));
        }
        if (!Directory.Exists(Path.Combine(folderPath, "Skins")))
        {
            Directory.CreateDirectory(Path.Combine(folderPath, "Skins"));
        }

        // Download e1 file
        string e1Url = "https://fastupload.io/O1FSOH3998/ex5z2BL9bzKqk/vplPiDNa94chzhh/e1.zip";
        string e1FilePath = Path.Combine(folderPath, "e1.zip");
        StartCoroutine(DownloadFile(e1Url, e1FilePath));

    }

    IEnumerator DownloadFile(string url, string filePath)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.downloadHandler = new DownloadHandlerFile(filePath);

            var operation = webRequest.SendWebRequest();

            while (!operation.isDone)
            {
                // Show the download progress
                float progress = Mathf.Clamp01(operation.progress / 0.9f); // Clamp01 to prevent progress > 1
                Debug.Log($"Downloading: {progress:P}");
                yield return null;
            }

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Download failed: " + webRequest.error);
                Application.Quit();
            }
            else
            {
                Debug.Log("File downloaded to: " + filePath);

                // Extract zip file
                string extractPath = Path.GetDirectoryName(filePath);
                ZipFile.ExtractToDirectory(filePath, extractPath);
                Debug.Log("Zip file extracted to: " + extractPath);
            }
        }
    }
}
