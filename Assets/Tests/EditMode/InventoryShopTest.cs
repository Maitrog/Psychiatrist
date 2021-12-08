using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryShopTest
{
    [Test]
    public void CheckInventory()
    {
        ItemsDatabaseObject db = UnityEngine.Resources.Load<ItemsDatabaseObject>("ItemsDatabase");
        Assert.AreEqual(db.items.Length, 5);
    }
}
