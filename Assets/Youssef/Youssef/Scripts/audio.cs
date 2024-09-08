using UnityEngine;
using UnityEngine.UI;

public class AudioPlayerController : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public Button playButton;       // Reference to the UI Button

    void Start()
    {
        if (audioSource == null) Debug.LogError("AudioSource is not assigned!");
        if (playButton == null) Debug.LogError("PlayButton is not assigned!");

        playButton.onClick.AddListener(ToggleAudio);
    }

    void ToggleAudio()
    {
        if (audioSource.isPlaying)
        {
            Debug.Log("Audio is currently playing. Pausing the audio.");
            audioSource.Pause();
        }
        else
        {
            Debug.Log("Audio is not playing. Starting the audio.");
            audioSource.Play();
        }
    }

    void Update()
    {
        // Additional check in the Update method to log the current state
        if (audioSource.isPlaying)
        {
            Debug.Log("Audio is playing.");
        }
        else
        {
            Debug.Log("Audio is not playing.");
        }
    }
}