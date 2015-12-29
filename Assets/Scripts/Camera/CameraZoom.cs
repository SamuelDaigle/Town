using UnityEngine;
using System.Collections;
using Utilities;

public class CameraZoom : MonoBehaviour
{
    public float MinZoomDistance = 3f;
    public float MaxZoomDistance = 10f;
    void FixedUpdate()
    {
        Camera.main.orthographicSize += InputManager.GetDeltaZoom();
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, MinZoomDistance, MaxZoomDistance);
    }
}
