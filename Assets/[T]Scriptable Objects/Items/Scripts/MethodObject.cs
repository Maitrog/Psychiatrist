using UnityEngine;

[CreateAssetMenu(fileName = "New Tablet", menuName = "Inventory System/Items/Methods")]
public class MethodObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Methods;
    }
}
