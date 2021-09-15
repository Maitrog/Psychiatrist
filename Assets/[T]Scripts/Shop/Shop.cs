using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public ShopObject shop;
    public void Start()
    {
        Debug.Log("shop");
        for (int i = 0; i < 4; i++)
        {
            shop.openedItems.Add(i);
        }
    }
    private void OnApplicationQuit()
    {
        shop.openedItems = new List<int>();
    }
}
