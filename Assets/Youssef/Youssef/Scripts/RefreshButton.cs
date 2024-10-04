using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public Slider videoSlider;       // Assign your slider in the inspector
    public VideoPlayer videoPlayer;  // Assign your video player in the inspector
    public GameObject restartButton; // Assign your restart button in the inspector

    void Start()
    {
        // Ensure the button is hidden at the start
        restartButton.SetActive(false);

        // Optionally, listen to slider value changes
        videoSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void Update()
    {
        // Check if the video is finished
        if (videoPlayer.frame >= (long)videoPlayer.frameCount)
        {
            ShowRestartButton();
        }
    }

    private void OnSliderValueChanged(float value)
    {
        // If the slider reaches 100, show the restart button
        if (value >= 0.95)
        {
            ShowRestartButton();
        }
    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true); // Show the button
    }

    public void OnRestartButtonClick()
    {
        // Restart the video
        videoPlayer.Stop();
        videoPlayer.Play();

        // Hide the button again
        restartButton.SetActive(false);
    }
}
