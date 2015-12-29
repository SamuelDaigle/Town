using UnityEngine;
using System.Collections;
using Utilities;

public class CameraMovement : MonoBehaviour
{
    public float CameraSensibility = 0.5f;

    void Start()
    {
        Mathf.Clamp(CameraSensibility, 0.0f, 1.0f);
    }

    void FixedUpdate()
    {
        Vector2 touchPosition = InputManager.GetDeltaPosition();
        transform.Translate(-touchPosition.x * CameraSensibility, 0, -touchPosition.y * CameraSensibility);
    }
}
