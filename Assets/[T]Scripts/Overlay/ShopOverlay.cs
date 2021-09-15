using UnityEngine;

public class ShopOverlay : MonoBehaviour
{
    public static bool isOverlay = false;
    public GameObject overlay;

    public void Awake()
    {
        overlay.SetActive(false);
    }
    public void OpenOverlay()
    {
        overlay.SetActive(true);
        isOverlay = true;
    }

    public void CloseOverlay()
    {
        overlay.SetActive(false);
        isOverlay = false;
    }
}
