using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteOnClick : MonoBehaviour
{
    public Image targetImage;       // The Image component whose sprite you want to change
    public Sprite sprite1;          // The first sprite (initial sprite)
    public Sprite sprite2;          // The second sprite (new sprite to toggle to)

    private bool isSprite1Active;   // A flag to track which sprite is currently active

    void Start()
    {
        // Set initial state
        if (targetImage != null)
        {
            targetImage.sprite = sprite1; // Set the initial sprite
            isSprite1Active = true;       // Start with sprite1
        }
    }

    // This method is called when the button is clicked
    public void OnButtonClick()
    {
        if (targetImage != null)
        {
            if (isSprite1Active)
            {
                targetImage.sprite = sprite2; // Change to sprite2
            }
            else
            {
                targetImage.sprite = sprite1; // Change back to sprite1
            }

            // Toggle the flag
            isSprite1Active = !isSprite1Active;
        }
    }
}
