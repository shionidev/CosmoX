using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.CodeDom.Compiler;

public class Notisys : MonoBehaviour
{
    // Reference to the notification prefab
    public GameObject notificationPrefab;

    // Reference to the canvas that will hold the notifications
    public Canvas notificationCanvas;

    // Duration of the notification display in seconds
    public float notificationDuration = 3f;

    // Queue to hold the notifications
    private Queue<GameObject> notificationQueue = new Queue<GameObject>();

    // Function to add a new notification to the queue
    public void AddNotification(string content)
    {
        // Instantiate the notification prefab
        GameObject newNotification = Instantiate(notificationPrefab, notificationCanvas.transform);

        // Set the text of the notification to the given content
        newNotification.GetComponentInChildren<Text>().text = content;

        // Add the notification to the queue
        notificationQueue.Enqueue(newNotification);

        // Update the positions of all notifications in the queue
        UpdateNotificationPositions();
        
        // Start a coroutine to remove the notification after a set duration
        StartCoroutine(RemoveNotification(newNotification));
    }

    // Coroutine to remove a notification after a set duration
    IEnumerator RemoveNotification(GameObject notification)
    {
        yield return new WaitForSeconds(notificationDuration);

        // Remove the notification from the queue and destroy the game object
        notificationQueue.Dequeue();
        Destroy(notification);

        // Update the positions of all notifications in the queue
        UpdateNotificationPositions();
    }

    // Function to update the positions of all notifications in the queue
    private void UpdateNotificationPositions()
    {
        int position = 0;
        foreach (GameObject notification in notificationQueue)
        {
            RectTransform rt = notification.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(0, position);
            position -= (int)rt.rect.height;
        }
    }
}
