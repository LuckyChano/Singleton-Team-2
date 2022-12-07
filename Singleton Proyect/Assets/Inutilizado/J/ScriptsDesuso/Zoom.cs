using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] float zoomSpeed = 5;

    [SerializeField] float maxZoomOrtographic = 5;
    [SerializeField] float minZoomOrtographic = 20;

    [SerializeField] float maxZoom = 20;
    [SerializeField] float minZoom = 120;

    private void Update()
    {
        if (Input.touchCount < 2) return;
        if (Input.touches[0].phase != TouchPhase.Moved && Input.touches[1].phase != TouchPhase.Moved) return;

        Vector2 OneTouchP = Input.touches[0].position;
        Vector2 TwoTouchP = Input.touches[1].position;

        Vector2 prevOneTouchP = OneTouchP - Input.touches[0].deltaPosition;
        Vector2 prevTwoTouchP = TwoTouchP - Input.touches[1].deltaPosition;

        Vector2 currentTouchesVector = OneTouchP - TwoTouchP;
        Vector2 prevTouchesVector = prevOneTouchP - prevTwoTouchP;

        float zoom = currentTouchesVector.magnitude - prevTouchesVector.magnitude;

        if (zoom != 0)
        {
            if (Camera.main.orthographic)
            {
                Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + zoom * zoomSpeed * Time.deltaTime, maxZoomOrtographic, minZoomOrtographic);
            }
            else
            {
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView + zoom * zoomSpeed * Time.deltaTime, maxZoom, minZoom);
            }
        }
    }
}
