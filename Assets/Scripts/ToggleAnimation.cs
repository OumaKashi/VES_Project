using UnityEngine;

public class ToggleAnimation : MonoBehaviour
{
    public Animator animator;  // Reference to the Animator component
    public string animationName;  // Name of the animation state to toggle

    private bool isPlaying = false;  // Track the animation state

    public void ToggleAnimationState()
    {
        if (isPlaying)
        {
            // Reset the animation to its initial state
            animator.Play(animationName, -1, 0f);
            animator.speed = 0;  // Pause the animation to hold it at the initial frame
        }
        else
        {
            // Play the animation from the start
            animator.speed = 1;  // Resume normal playback speed
            animator.Play(animationName);
        }

        isPlaying = !isPlaying;  // Toggle the state
    }
}