using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    public static float GetScreenToWorldHeight
    {
        get
        {
            Vector3 topRightCorner = new Vector3(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
            var height = edgeVector.y * 2;
            return height;
        }
    }
    public static float GetScreenToWorldWidth
    {
        get
        {
            Vector3 topRightCorner = new Vector3(1, 1);
            Vector3 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
            var width = edgeVector.x * 2;
            return width;
        }
    }
}
