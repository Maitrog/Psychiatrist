using UnityEngine;

public class Methods : MonoBehaviour
{
    public MethodsObject inventory;

    private void Update()
    {

    }
    private void OnApplicationQuit()
    {
        inventory.container.items = new InventorySlot[3];
    }
}
