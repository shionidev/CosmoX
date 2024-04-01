using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Frames : MonoBehaviour
{
    public TextMeshProUGUI fpsCounter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
void Update()
{
    float fps = 1.0f / Time.deltaTime;
    fpsCounter.text = " " + Mathf.RoundToInt(fps).ToString() + " FPS";
}


}
