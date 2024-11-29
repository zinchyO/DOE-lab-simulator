using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IDSwipeManager : MonoBehaviour
{
    public Canvas successCanvas; // Assign the Canvas you want to show
    public float displayDuration = 10f; // Duration to display the canvas
    public float delayBeforeShowingCanvas = 2f; // Delay before showing the canvas
    public string targetSceneName; // Name of the scene to load after displaying the canvas

    private bool isCanvasShown = false; // Prevent multiple triggers

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the ID
        if (other.CompareTag("ID_Object") && !isCanvasShown)
        {
            isCanvasShown = true; // Prevent re-triggering
            StartCoroutine(DelayedShowCanvas());
        }
    }

    private IEnumerator DelayedShowCanvas()
    {
        // Wait for the specified delay before showing the canvas
        yield return new WaitForSeconds(delayBeforeShowingCanvas);
        ShowCanvas();
    }

    private void ShowCanvas()
    {
        // Enable the Canvas
        if (successCanvas != null)
        {
            successCanvas.gameObject.SetActive(true);
        }

        // Start a Coroutine to wait and load the next scene
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Load the next scene
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("Target scene name is not set!");
        }
    }
}