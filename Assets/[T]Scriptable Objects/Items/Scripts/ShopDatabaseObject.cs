using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Database", menuName = "Inventory System/Items/Shop Database")]
public class ShopDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemsDatabaseObject database;
    public Dictionary<int, int> cost = new Dictionary<int, int>();//id - cost
    public int[] costs;

    public void OnAfterDeserialize()
    {
        for (int i  = 0; i < costs.Length; i++)
        {
            cost.Add(i, costs[i]);
        }
    }
    
    public void OnBeforeSerialize()
    {
        cost = new Dictionary<int, int>();
        if (costs.Length != database.items.Length)
            costs = new int[database.items.Length];
    } 
}
