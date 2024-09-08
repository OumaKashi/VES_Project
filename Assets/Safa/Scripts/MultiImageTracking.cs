using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MultiImageTracking : MonoBehaviour
{
	public ARTrackedImageManager trackedImageManager;
	public List<GameObject> objectPrefabs; // List of object prefabs to be instantiated
	public GameObject objectToDisable; // The GameObject to disable/enable based on tracking

	private Dictionary<string, GameObject> spawnedObjects = new Dictionary<string, GameObject>();

	void OnEnable()
	{
		trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
	}

	void OnDisable()
	{
		trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
	}

	private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
	{
		foreach (ARTrackedImage trackedImage in eventArgs.added)
		{
			UpdateTrackedImage(trackedImage);
		}

		foreach (ARTrackedImage trackedImage in eventArgs.updated)
		{
			UpdateTrackedImage(trackedImage);
		}

		foreach (ARTrackedImage trackedImage in eventArgs.removed)
		{
			if (spawnedObjects.ContainsKey(trackedImage.referenceImage.name))
			{
				Destroy(spawnedObjects[trackedImage.referenceImage.name]);
				spawnedObjects.Remove(trackedImage.referenceImage.name);
			}
		}

		// Enable the object if no images are being tracked
		bool anyImageTracking = false;
		foreach (ARTrackedImage trackedImage in trackedImageManager.trackables)
		{
			if (trackedImage.trackingState == TrackingState.Tracking)
			{
				anyImageTracking = true;
				break;
			}
		}

		objectToDisable.SetActive(!anyImageTracking);
	}

	private void UpdateTrackedImage(ARTrackedImage trackedImage)
	{
		string imageName = trackedImage.referenceImage.name;

		// Check if the object is already instantiated for this image
		if (!spawnedObjects.ContainsKey(imageName))
		{
			// Instantiate the corresponding object if it matches the image name
			foreach (var prefab in objectPrefabs)
			{
				if (prefab.name == imageName)
				{
					GameObject spawnedObject = Instantiate(prefab, trackedImage.transform.position, trackedImage.transform.rotation);
					spawnedObject.transform.parent = trackedImage.transform;
					spawnedObjects[imageName] = spawnedObject;
					break;
				}
			}
		}
		else
		{
			// Update the position and rotation of the tracked object
			GameObject trackedObject = spawnedObjects[imageName];
			trackedObject.transform.position = trackedImage.transform.position;
			trackedObject.transform.rotation = trackedImage.transform.rotation;
		}

		// Enable or disable the object based on the tracking state
		if (spawnedObjects.ContainsKey(imageName))
		{
			spawnedObjects[imageName].SetActive(trackedImage.trackingState == TrackingState.Tracking);
		}

		// Disable the specified GameObject when the image is tracked
		if (trackedImage.trackingState == TrackingState.Tracking)
		{
			objectToDisable.SetActive(false);
		}
	}
}
