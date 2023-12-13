using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{
    public float countdownTime = 3f;
    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
