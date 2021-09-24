using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public ItemObject item;
    public GameObject inventoryObject;
    public void AddReward()
    {
        Inventory inventory = inventoryObject.GetComponent<Inventory>();
        inventory.inventory.AddItem(new Item(item), 1);
    }

    public void AddGold()
    {
        Inventory inventory = inventoryObject.GetComponent<Inventory>();
        inventory.inventory.resources.AddOneGold();
    }
}
