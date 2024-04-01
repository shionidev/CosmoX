using RiptideNetworking;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _singleton;
    public static UIManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(UIManager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }

    [Header("Connect")]
    [SerializeField] private GameObject connectUI;
    [SerializeField] private GameObject ConnectedToServer;
    [SerializeField] private GameObject contactUI;
    [SerializeField] private GameObject Design;
    [SerializeField] private InputField usernameField;

    private void Awake()
    {
        Singleton = this;
    }

    public void ConnectClicked()
    {
        contactUI.SetActive(true);ConnectedToServer.SetActive(true);
        usernameField.interactable = false;
        connectUI.SetActive(false);Design.SetActive(false);

        NetworkManager.Singleton.Connect();
    }

    public void BackToMain()
    {
        usernameField.interactable = true;contactUI.SetActive(false);
        connectUI.SetActive(true);Design.SetActive(true);
    }

    public void SendName()
    {
        Message message = Message.Create(MessageSendMode.reliable, (ushort)ClientToServerId.name);
        message.AddString(usernameField.text);
        NetworkManager.Singleton.Client.Send(message);
    }
}