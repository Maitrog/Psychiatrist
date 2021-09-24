using UnityEngine;

public class Scaler : MonoBehaviour
{
    void Awake()
    {
        float width = ScreenSize.GetScreenToWorldWidth;
        transform.localScale = Vector3.one * width;
    }
}
