using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using RiptideNetworking;
using RiptideNetworking.Utils;
using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
using System.Threading;

namespace UpdaterManager
{
    [System.Serializable]
    struct GameData
    {
        public string Description;
        public string Version;
        public string Url;
    }

    public class UpdaterManager : MonoBehaviour
    {
        private static UpdaterManager _singleton;
        public static UpdaterManager Singleton
        {
            get => _singleton;
            private set
            {
                if (_singleton == null)
                    _singleton = value;
                else if (_singleton != value)
                {
                    Debug.Log($"{nameof(UpdaterManager)} instance already exists, destroying duplicate!");
                    Destroy(value);
                }
            }
        }

        [Header("UI References")]
        [SerializeField] private GameObject uiCanvas;
        [SerializeField] private Button uiUpdateButton;
        [SerializeField] private TextMeshProUGUI uiDescriptionText;

        [Space(20f)]
        [Header("Settings")]
        [SerializeField] [TextArea(1, 5)] private string jsonDataURL;

        private static bool isAlreadyCheckedForUpdates = false;
        public TMP_Text textComponent;
        public TMP_Text textDescription;
        public GameObject Interface;
        public GameObject HexiumErrorMessage;
        public GameObject LoadingComponent;
        public string MainScene;

        private void Awake()
        {
            Singleton = this;
        }

        [Obsolete]
        private void Start()
        {
            if (textComponent == null)
            {
                Debug.LogError("TextMesh Pro text component not assigned!");
                return;
            }

            if (Interface != null)
                Interface.SetActive(false);

            StartCoroutine(Updater());
        }

        [Obsolete]
        private IEnumerator Updater()
        {
            textComponent.text = "Checking client version...";
            textDescription.text = "This might take a while";
            yield return new WaitForSeconds(9f);
            Debug.Log("Checking your client version...");
            StartCheckForUpdates();
            Debug.Log("Client version has been checked...");
            textComponent.text = "";
            textDescription.text = "";
            ChangingSceneToMainScene();

        }

        [Obsolete]
        private void StartCheckForUpdates()
        {
            if (!isAlreadyCheckedForUpdates)
            {
                StopAllCoroutines();
                StartCoroutine(CheckForUpdates());
            }
        }

        public void ChangingSceneToMainScene()
        {
            Thread.Sleep(1500);
            SceneManager.LoadScene(MainScene);
            
        }

[Obsolete]
private IEnumerator CheckForUpdates()
{
    UnityWebRequest request = UnityWebRequest.Get(jsonDataURL);
    request.chunkedTransfer = false;
    request.disposeDownloadHandlerOnDispose = true;
    request.timeout = 60;

    yield return request.SendWebRequest();

    if (request.isDone)
    {
        isAlreadyCheckedForUpdates = true;

        if (request.result == UnityWebRequest.Result.Success)
        {
            GameData latestGameData = JsonUtility.FromJson<GameData>(request.downloadHandler.text);
            if (!string.IsNullOrEmpty(latestGameData.Version) && !Application.version.Equals(latestGameData.Version))
            {
                uiDescriptionText.text = latestGameData.Description;
                ShowPopup();
            }
        }
    }

    request.Dispose();
}


        private void ShowPopup()
        {
            uiUpdateButton.onClick.AddListener(() =>
            {
                Application.Quit();
                Debug.Log("Closing Application...");
                Debug.Log("Ending Tasks...");
                HidePopup();
            });

            uiCanvas.SetActive(true);
            Interface.SetActive(false);
            LoadingComponent.SetActive(false);
            Debug.LogError("Your client version is not up to date...");
        }

        private void HidePopup()
        {
            uiCanvas.SetActive(false);
            uiUpdateButton.onClick.RemoveAllListeners();
        }

        private void OpenHexium()
        {
            // Specify the path to the Updater folder
            string updaterFolderPath = Path.Combine(Application.dataPath, "Updater");

            // Specify the path to hexium.exe within the Updater folder
            string hexiumPath = Path.Combine(updaterFolderPath, "hexium.exe");

            // Check if the file exists
            if (File.Exists(hexiumPath))
            {
                // Start the process
                Process.Start(hexiumPath);
            }
            else
            {
                Debug.LogError("hexium.exe not found in the Updater folder.");
            }
        }

            private void ErrorHexium()
            {
                HexiumErrorMessage.SetActive(true);
            }
        }
    }
