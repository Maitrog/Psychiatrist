using UnityEngine;

public class Scaler : MonoBehaviour
{
    void Awake()
    {
        float width = ScreenSize.GetScreenToWorldWidth;
        transform.localScale = 0.8f * width * Vector3.one/*transform.localScale*/;
    }
}
