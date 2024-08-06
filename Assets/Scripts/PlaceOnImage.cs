using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnImage : MonoBehaviour
{
    private ARTrackedImageManager imageManager;

    public int count;

    public bool debug = false;

    public TMPro.TMP_Text countText;
    public TMPro.TMP_Text stateText;

    // Start is called before the first frame update
    void Start()
    {
        imageManager = FindObjectOfType<ARTrackedImageManager>(true);
        InvokeRepeating("ImageData", 1, 1);
    }

    private void ImageData()
    {
        count = imageManager.trackables.count;


        countText.text = count.ToString();

        foreach (var trackedImage in imageManager.trackables)
        {
            stateText.text = trackedImage.referenceImage.name + "\n = " + trackedImage.trackingState.ToString();

            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                //countText.text = "si";
                trackedImage.GetComponentInChildren<Canvas>().enabled = true;
            }
            else
            {
                //countText.text = "no";
                trackedImage.GetComponentInChildren<Canvas>().enabled = false;
            }
        }
    }
}
