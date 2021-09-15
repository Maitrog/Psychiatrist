using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryObject inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.Load();
        }
    }
    private void OnApplicationQuit()
    {
        inventory.container.items = new InventorySlot[15];
        inventory.resources.gold = 0;
    }
    /*
    private void Start()
    {
        inventory.container.items = new InventorySlot[15];
    }
    */
}
