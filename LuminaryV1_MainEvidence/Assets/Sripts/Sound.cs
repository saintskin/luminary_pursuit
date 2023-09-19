using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource you want to toggle.
    private bool isSoundOn = true;  // Track the sound state.

    private void Start()
    {
        // Ensure the audio source is not null and initially set to play.
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource reference not set.");
        }
        else
        {
            audioSource.playOnAwake = isSoundOn;
        }
    }

    public void ToggleSound()
    {
        // Check if the audio source is valid.
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource reference not set.");
            return;
        }

        // Toggle the sound state.
        isSoundOn = !isSoundOn;

        // Set the audio source to play or stop based on the sound state.
        if (isSoundOn)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
}
