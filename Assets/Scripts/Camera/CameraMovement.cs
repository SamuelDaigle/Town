using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float CameraSensibility = 0.5f;

#if UNITY_EDITOR
    private Vector3 oldMousePosition;
#endif

    void Start()
    {
        Mathf.Clamp(CameraSensibility, 0.0f, 1.0f);
    }

    void FixedUpdate()
    {
        Vector2 touchPosition = Vector2.zero;
#if UNITY_ANDROID
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.deltaPosition * CameraSensibility;
        }
#elif UNITY_EDITOR
        if (Input.GetMouseButton(1))
        {
            touchPosition = Input.mousePosition - oldMousePosition;
        }
        oldMousePosition = Input.mousePosition;
#endif
        Camera.main.transform.Translate(-touchPosition.x * CameraSensibility, -touchPosition.y * CameraSensibility, 0);
    }
}
