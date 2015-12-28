using UnityEngine;
using System.Collections;

public class DayTime : MonoBehaviour
{
    public float MinRotation = 35;
    public float MaxRotation = 90;

    public float FullDayTime = 180;
    public float FullNightTime = 60;

    public float RotationSpeed = 0.1f;
    private float rotationRate;

    // Use this for initialization
    void Start()
    {
        transform.localEulerAngles = new Vector3((MaxRotation + MinRotation) / 2, 0, 0);
        GoToDay();
    }

    // Update is called once per frame after the physics
    void LateUpdate()
    {
        // Modify the rotation;
        transform.Rotate(rotationRate, 0, 0);

        if (transform.localEulerAngles.x <= MinRotation || transform.localEulerAngles.x >= MaxRotation)
        {
            if (rotationRate > 0)
            {
                Invoke("GoToDay", FullNightTime);
            }
            else if (rotationRate < 0)
            {
                Invoke("GoToNight", FullDayTime);
            }
            rotationRate = 0;
        }
    }

    private void GoToDay()
    {
        Debug.Log("DayTime");
        rotationRate = -1 * RotationSpeed;
    }

    private void GoToNight()
    {
        Debug.Log("NightTime");
        rotationRate = 1 * RotationSpeed;
    }
}
