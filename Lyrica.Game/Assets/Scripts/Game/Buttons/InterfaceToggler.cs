using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class InterfaceToggler : MonoBehaviour
{

    public GameObject Interface1;
    public GameObject Interface2;
    public void OpenInterface1()
    {
        Interface1.SetActive(true);
    }
    public void CloseInterface1()
    {
        Interface1.SetActive(false);
    }

    public void OpenInterface2()
    {
        Interface2.SetActive(true);
    }
    public void CloseInterface2()
    {
        Interface2.SetActive(false);
    }
}