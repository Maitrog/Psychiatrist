using UnityEngine;

[CreateAssetMenu(fileName = "New Device", menuName = "Inventory System/Items/Devices")]
public class DeviceObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Devices;
    }
}
