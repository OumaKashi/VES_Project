using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceHandler : MonoBehaviour
{
	public AudioSource[] audioSources; // Array to hold the AudioSource components
	private AudioSource currentAudioSource; // The currently playing audio source

	public GameObject targetObject;  // The GameObject you want to toggle
	public Button audioButton;      // Reference to the UI Button
	private bool isActive = false;   // Keeps track of the current state

	// Call this method when a button is clicked, passing the index of the AudioSource
	public void PlayAudio(int index)
	{
		// Check if there's an audio source currently playing
		if (currentAudioSource != null && currentAudioSource.isPlaying)
		{
			// Stop the current audio
			currentAudioSource.Stop();
		}

		// Assign the new audio source and play it
		currentAudioSource = audioSources[index];
		currentAudioSource.Play();
	}

	// Call this method when the stop button is clicked
	public void StopAllAudios()
	{
		// Stop all audio sources in the array
		foreach (AudioSource audioSource in audioSources)
		{
			audioSource.Stop();
		}

		// Reset the currentAudioSource reference
		currentAudioSource = null;
	}

	void Start()
	{
		// Set the initial state of the GameObject
		targetObject.SetActive(isActive);

		// Add listener to the button to call ToggleObject when clicked
		audioButton.onClick.AddListener(ToggleObject);
	}

	void ToggleObject()
	{
		// Toggle the state
		isActive = !isActive;

		// Set the GameObject's active state based on the toggle
		targetObject.SetActive(isActive);
	}
}
