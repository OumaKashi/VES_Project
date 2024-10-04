using UnityEngine;

public class OpenLink : MonoBehaviour
{
    // Public field for the URL that can be set in the Unity Inspector
    public string url;

    // Method to open the URL
    public void OpenExternalLink()
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
        else
        {
            Debug.LogWarning("URL is not set for this button.");
        }
    }
}
