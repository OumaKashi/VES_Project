using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems; // Needed for IPointerDownHandler and IPointerUpHandler interfaces

public class VideoRotationController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button muteButton;       // Button for muting/unmuting audio
    public Button pausePlayButton;  // Button for pausing/playing the video
    public Slider progressBar;      // Slider for showing video progress
    public VideoPlayer videoPlayer; // VideoPlayer component

    private bool isMuted = false;  // Flag to check mute state
    private bool isPaused = false; // Flag to check pause state
    private bool isDragging = false; // Flag to check if the slider is being dragged

    void Start()
    {
        // Check for required components
        if (muteButton == null || pausePlayButton == null || progressBar == null || videoPlayer == null)
        {
            Debug.LogError("Some UI components are not assigned!");
            return;
        }

        // Add listeners to buttons
        muteButton.onClick.AddListener(ToggleMute);
        pausePlayButton.onClick.AddListener(TogglePausePlay);
        progressBar.onValueChanged.AddListener(OnSliderValueChanged);

        // Set initial size based on aspect ratio once the video player is prepared
        videoPlayer.prepareCompleted += OnVideoPrepared;

        // Start video preparation
        videoPlayer.Prepare();
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        // Adjust the video to fit the screen based on the aspect ratio

        // Start the video
        videoPlayer.Play();
    }

    void Update()
    {
        // Update the slider value based on video time if not being dragged
        if (videoPlayer.isPlaying && !isDragging)
        {
            progressBar.value = (float)(videoPlayer.time / videoPlayer.length);
        }
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        videoPlayer.SetDirectAudioMute(0, isMuted);
    }

    void TogglePausePlay()
    {
        if (isPaused)
        {
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();
        }
        isPaused = !isPaused;
    }

    void OnSliderValueChanged(float value)
    {
        if (!isDragging) // Only change time when not dragging
        {
            videoPlayer.time = value * videoPlayer.length;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        // Update the video time based on the final slider position
        videoPlayer.time = progressBar.value * videoPlayer.length;
    }
}
