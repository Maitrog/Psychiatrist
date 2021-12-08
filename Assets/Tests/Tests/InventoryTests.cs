using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTests
{
    ItemsDatabaseObject idb = UnityEngine.Resources.Load<ItemsDatabaseObject>("ItemsDatabase");
    ShopDatabaseObject sdb = UnityEngine.Resources.Load<ShopDatabaseObject>("ShopDatabase");

    [Test]
    public void CheckInventoryCount()
    {
        Assert.AreEqual(idb.items.Length, 5);
        Assert.AreEqual(sdb.costs.Length, 5);
    }

    [Test]
    public void CheckInventoryItems()
    {
        for (int i = 0; i < idb.items.Length; i++)
        {
            Assert.IsNotNull(idb.items[i].uiDisplay);
            Assert.GreaterOrEqual(idb.items[i].Id, 0);
            Assert.IsNotNull(idb.items[i].type);
            Assert.IsNotNull(idb.items[i].toxicity);
            Assert.IsNotNull(idb.items[i].character);
        }
    }

    [Test]
    public void CheckShopItems()
    {
        Assert.AreEqual(idb.items.Length, sdb.costs.Length);
        for (int i = 0; i < sdb.costs.Length; i++)
        {
            Assert.Greater(sdb.costs[i], 0);
        }
    }
}
