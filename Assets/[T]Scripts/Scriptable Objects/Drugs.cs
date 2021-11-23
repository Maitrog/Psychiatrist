using UnityEngine;

public class Drugs : MonoBehaviour
{
    public DrugsObject inventory;

    private void OnApplicationQuit()
    {
        inventory.Save();
        //inventory.container.items = new InventorySlot[3];
    }
}
