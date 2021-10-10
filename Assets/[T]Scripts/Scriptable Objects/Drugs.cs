using UnityEngine;

public class Drugs : MonoBehaviour
{
    public DrugsObject inventory;

    private void Update()
    {

    }
    private void OnApplicationQuit()
    {
        inventory.container.items = new InventorySlot[3];
    }
}
