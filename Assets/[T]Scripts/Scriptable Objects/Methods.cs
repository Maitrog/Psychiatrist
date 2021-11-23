using UnityEngine;

public class Methods : MonoBehaviour
{
    public MethodsObject inventory;

    private void OnApplicationQuit()
    {
        inventory.Save();
        //inventory.container.items = new InventorySlot[3];
    }
}
