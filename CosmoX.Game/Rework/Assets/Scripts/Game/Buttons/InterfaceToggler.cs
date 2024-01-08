using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class InterfaceToggler : MonoBehaviour
{

    public GameObject ActivateInterface;
    public GameObject DectivateInterface;
    public void Open()
    {
        ActivateInterface.SetActive(true);
        DectivateInterface.SetActive(false);
    }
    public void Close()
    {
        ActivateInterface.SetActive(false);
        DectivateInterface.SetActive(true);
    }
}