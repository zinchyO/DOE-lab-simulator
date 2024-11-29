using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using TMPro;
//using static System.Net.Mime.MediaTypeNames;

public class BadgeMachine : MonoBehaviour
{
    // Assign these in the Unity Inspector
    public TextMeshProUGUI displayText; // UI Text for messages ("Access Granted", "Access Denied", etc.)
    public Renderer wallRenderer; // Renderer for the wall object to change its color/material
    public Material successMaterial; // Material to apply on success
    public Material failureMaterial; // Material to apply on failure
    public Material defaultMaterial; // Material to apply by default (reset state)

    // Optional audio feedback
    public AudioSource audioSource; // Assign an AudioSource component for sound effects
    public AudioClip successBeep; // Beep sound for success
    public AudioClip failureBeep; // Beep sound for failure
    private void Start()
    {
        // Set the initial material to defaultMaterial
        if (wallRenderer != null && defaultMaterial != null)
        {
            wallRenderer.material = defaultMaterial;
        }
    }
    // Trigger detection for the ID object
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the ID object
        if (other.CompareTag("ID_Object"))
        {
            // Update display text to indicate success
            if (displayText != null)
            {
                displayText.text = "Access Granted";
            }

            // Change wall color or material to success
            if (wallRenderer != null && successMaterial != null)
            {
                wallRenderer.material = successMaterial;
            }

            // Play success beep sound
            if (audioSource != null && successBeep != null)
            {
                audioSource.PlayOneShot(successBeep);
            }

            Debug.Log("Access Granted: Beep!");
        }
        else
        {
            // If it's not the ID object, indicate failure
            if (displayText != null)
            {
                displayText.text = "Access Denied";
            }

            // Change wall color or material to failure
            if (wallRenderer != null && failureMaterial != null)
            {
                wallRenderer.material = failureMaterial;
            }

            // Play failure beep sound
            if (audioSource != null && failureBeep != null)
            {
                audioSource.PlayOneShot(failureBeep);
            }

            Debug.Log("Access Denied: Beep!");
        }
    }

    // Reset the wall display and material when the object exits the trigger
    private void OnTriggerExit(Collider other)
    {
        // Reset only if the ID object leaves
        if (other.CompareTag("ID_Object"))
        {
            // Reset display text to default message
            if (displayText != null)
            {
                displayText.text = "Waiting for ID";
            }

            // Reset wall color or material to default
            if (wallRenderer != null && defaultMaterial != null)
            {
                wallRenderer.material = defaultMaterial;
            }

            Debug.Log("Waiting for ID...");
        }
    }
}