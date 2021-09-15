using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Inventory System/Shop")]
public class ShopObject : ScriptableObject
{
    public string savePath;
    public ShopDatabaseObject database;
    public List<int> openedItems = new List<int>();

    public void OpenItem(int _id)
    {
        if (openedItems.Contains(_id) == false)
            openedItems.Add(_id);
    }
}
