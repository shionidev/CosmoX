using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class InterfaceToggler : MonoBehaviour
{

    public GameObject ActivateInterface;
    public GameObject DeactivateInterface;
    public GameObject CutScene;
    public GameObject OnlyInterface;
    public void Open()
    {
        ActivateInterface.SetActive(true);
        DeactivateInterface.SetActive(false);
    }
    public void Close()
    {
        ActivateInterface.SetActive(false);
        DeactivateInterface.SetActive(true);
    }

    public void CutActivate()
    {
        CutScene.SetActive(true);
    }

    public void CutDeactivate()
    {
        CutScene.SetActive(false);
    }

    public void OnlyInterfaceActivate()
    {
        OnlyInterface.SetActive(true);
    }

    public void OnlyInterfaceDeactivate()
    {
        OnlyInterface.SetActive(false);
    }
}