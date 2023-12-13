using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVisualizer : MonoBehaviour {
    public float minHeight = 15.0f;
    public float maxHeight = 425.0f;
    public float updateSensitivity = 0.5f;
    public Color visualizerColor = Color.gray;
    public AudioSource audioSource; // Changed variable name and type
    public bool loop = true;
    [Range (64,8192)]
    public int visualizerSamples = 64;
    public VisualizerObj[] visualizerObjects;
    
    // Start is called before the first frame update
    void Start() {
        visualizerObjects = GetComponentsInChildren<VisualizerObj>();

        if (!audioSource)
            return;
        
        audioSource.loop = loop;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update() {
        float[] spectrumData = new float[visualizerSamples];
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        for (int i = 0; i < visualizerObjects.Length; i++) {
            Vector2 newSize = visualizerObjects[i].GetComponent<RectTransform>().sizeDelta;

            newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, minHeight + (spectrumData[i] * (maxHeight - minHeight) * 5.0f), updateSensitivity), minHeight, maxHeight);
            visualizerObjects[i].GetComponent<RectTransform>().sizeDelta = newSize;

            visualizerObjects[i].GetComponent<Image>().color = visualizerColor;
        }
    }
}
