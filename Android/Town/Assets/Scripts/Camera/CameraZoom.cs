using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
    void Start()
    {
    }

    void FixedUpdate()
    {
        float zoomDelta = 0;
#if UNITY_ANDROID
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            zoomDelta = (touch2.position - touch1.position).magnitude;
        }
#elif UNITY_EDITOR
        zoomDelta = -Input.mouseScrollDelta.y;
#endif
        Camera.main.orthographicSize += zoomDelta;

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 0.01f, 6);
    }
}
