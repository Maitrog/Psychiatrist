using UnityEngine;

public class KeepInventory : MonoBehaviour
{
    public InventoryObject inventory;

    private void OnApplicationQuit()
    {
        inventory.Save();
    }
}
