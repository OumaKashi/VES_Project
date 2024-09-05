using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBarrage : MonoBehaviour
{
    public Animator barrageAnimator; // Reference to the Animator component for the door

    // This function is called when the door collider is touched
    public void OnMouseDown()
    {
        // Toggle the state of the door animation
        barrageAnimator.SetBool("isOpen", !barrageAnimator.GetBool("isOpen"));
    }
}