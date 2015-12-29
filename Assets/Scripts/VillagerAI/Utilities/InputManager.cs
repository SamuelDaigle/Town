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
    }
}
