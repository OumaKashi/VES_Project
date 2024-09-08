using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    public Image sliderHandle; // Reference to the slider handle image
    public Sprite[] sprites;   // Array to hold the sprites
    public float changeInterval = 1f; // Time interval between sprite changes

    private int currentSpriteIndex = 0; // Index to track the current sprite
    private float timer;

    void Start()
    {
        if (sprites.Length > 0)
        {
            sliderHandle.sprite = sprites[currentSpriteIndex]; // Set the initial sprite
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            timer = 0f; // Reset timer
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length; // Loop through sprites
            sliderHandle.sprite = sprites[currentSpriteIndex]; // Change the sprite
        }
    }
}
