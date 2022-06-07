using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Weathering
{
    public static class InputUtility
    {
        public const string Cross = "Cross";
        public const string Circle = "Circle";
        public const string Square = "Square";
        public const string Triangle = "Triangle";
        public const string LeftShoulder= "Left Shoulder";
        public const string RightShoulder = "Right Shoulder";
        public const string Start = "Start";
        public const string Select = "Select";
        public const string DPadUp = "D-Pad Up";
        public const string DPadRight = "D-Pad Right";
        public const string DPadDown = "D-Pad Down";
        public const string DPadLeft = "D-Pad Left";
        public const string LeftStickHorizontal = "Left Stick Horizontal";
        public const string LeftStickVertical = "Left Stick Vertical";
        public const string RightStickHorizontal = "Right Stick Horizontal";
        public const string RightStickVertical = "Right Stick Vertical";


        public static Vector2Int MapStickToDueDir(float x,float y,float DeathZone=0.25f)
        {
            float absX = Mathf.Abs(x);
            float absY = Mathf.Abs(y);
            if (absX > absY)
            {
                if (absX > DeathZone)
                {
                    if (x > 0)
                    {
                        return Vector2Int.right;
                    }
                    else
                    {
                        return Vector2Int.left;
                    }
                }
            }
            else
            {
                if (absY > DeathZone)
                {
                    if (y > 0)
                    {
                        return Vector2Int.up;
                    }
                    else
                    {
                        return Vector2Int.down;
                    }
                }
            }
            return Vector2Int.zero;
        }


    }

    public static class NativePluginUtility
    {
#if UNITY_PSP2
        [DllImport("UnityTimePlugin")]
        public static extern long getCurrentTick();
#endif

    }
}

