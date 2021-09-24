using UnityEngine;

[CreateAssetMenu(fileName = "New Tablet", menuName = "Inventory System/Items/Tablets")]
public class TabletObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Tablets;
    }
}
