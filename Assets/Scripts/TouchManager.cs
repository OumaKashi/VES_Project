using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Vector2 initialTouchPosition1;
    private Vector2 initialTouchPosition2;
    private float initialDistance;
    private Vector3 initialScale;
    private Transform objectTransform;

    private Vector2 initialOneFingerPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        objectTransform = transform;
        initialScale = objectTransform.localScale;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(0);

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialTouchPosition1 = touch1.position;
                initialTouchPosition2 = touch2.position;
                initialDistance = Vector2.Distance(initialTouchPosition1, initialTouchPosition2);
                initialScale = objectTransform.localScale;
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float scaleFactor = currentDistance / initialDistance;
            }
        }
    }
}