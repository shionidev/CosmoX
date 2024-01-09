using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Threading;

public class SceneTransfer : MonoBehaviour
{
    public string SelectedLevel;
    public GameObject FinalCut;

    // Start is called before the first frame update
    void Start()
    {
        FinalCut.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangingSceneToMainScene()
    {
        FinalCut.SetActive(true);
        SceneManager.LoadScene(SelectedLevel);
        Thread.Sleep(2000);
    }
}