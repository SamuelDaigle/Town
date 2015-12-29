using UnityEngine;
using System.Collections;

public class CameraLimit : MonoBehaviour
{
    public Transform limit;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    // Use this for initialization
    void Start()
    {
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize;
        Vector2 bottomLeft = Camera.main.WorldToScreenPoint(limit.position - limit.localScale / 2);
        Vector2 topRight = Camera.main.WorldToScreenPoint(limit.position + limit.localScale / 2);

        // Calculations assume map is position at the origin
        minX = limit.position.x - limit.localScale.x / 2;
        maxX = limit.position.x + limit.localScale.x / 2;
        minY = limit.position.y - limit.localScale.y / 2;
        maxY = limit.position.y + limit.localScale.y / 2;

        minX = Mathf.Clamp(minX, bottomLeft.x + screenWidth / 2, topRight.x - screenWidth / 2);
        minY = Mathf.Clamp(minY, bottomLeft.y + screenHeight / 2, topRight.y - screenHeight / 2);
        maxX = Mathf.Clamp(maxX, bottomLeft.x + screenWidth / 2, topRight.x - screenWidth / 2);
        maxY = Mathf.Clamp(maxY, bottomLeft.y + screenHeight / 2, topRight.y - screenHeight / 2);
    }

    // LateUpdate is called once per frame after the physics.
    void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
    }
}
