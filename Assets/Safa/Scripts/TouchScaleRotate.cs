using UnityEngine;

public class TouchScaleRotate : MonoBehaviour
{
	private Vector2 previousTouchPosition;
	private float initialDistance;
	private Vector3 initialScale;

	void Update()
	{
		if (Input.touchCount == 1) // Rotate
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				previousTouchPosition = touch.position;
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				Vector2 deltaPosition = touch.position - previousTouchPosition;
				float rotationSpeed = 0.2f;

				// Rotate based on deltaPosition.x for horizontal swipe
				transform.Rotate(0, -deltaPosition.x * rotationSpeed, 0, Space.World);

				// Update previous touch position
				previousTouchPosition = touch.position;
			}
		}
		else if (Input.touchCount == 2) // Scale
		{
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
			{
				initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
				initialScale = transform.localScale;
			}

			if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
			{
				float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
				if (Mathf.Approximately(initialDistance, 0)) return;

				float scaleFactor = currentDistance / initialDistance;
				transform.localScale = initialScale * scaleFactor;
			}
		}
	}
}
