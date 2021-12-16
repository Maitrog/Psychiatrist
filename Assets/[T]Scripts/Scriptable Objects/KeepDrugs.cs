using UnityEngine;

public class KeepDrugs : MonoBehaviour
{
    public DrugsObject inventory;

    private void OnApplicationQuit()
    {
        inventory.Save();
    }
}
