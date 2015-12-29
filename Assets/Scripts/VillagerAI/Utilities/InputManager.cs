using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Utilities
{
    public static class InputManager
    {
        private static Vector3 oldMousePosition;
        public static Vector2 GetDeltaPosition()
        {
            Vector2 deltaPosition = Vector2.zero;
#if UNITY_ANDROID
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                deltaPosition = touch.deltaPosition * CameraSensibility;
            }
#elif UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                deltaPosition = Input.mousePosition - oldMousePosition;
            }
            oldMousePosition = Input.mousePosition;
#endif
            return deltaPosition;
        }

        public static float GetDeltaZoom()
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
            return zoomDelta;
        }
    }
}
