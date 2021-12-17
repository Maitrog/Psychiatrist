using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryObject inventory;
    private static bool loaded = false;

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
        inventory.Save();
        //inventory.container.items = new InventorySlot[15];
        //inventory.resources.gold = 0;
    }
    /*
    private void Start()
    {
        inventory.Load();
        //inventory.container.items = new InventorySlot[15];
    }*/

    private void Awake()
    {
        /*
        if (!loaded)
        {
            inventory.Load();
            loaded = true;
        }*/
    }
}
