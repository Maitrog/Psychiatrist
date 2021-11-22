using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayShopItems : MonoBehaviour
{
    public GameObject prefab;
    public GameObject inventory;
    public ShopObject shop;
    public List<int> displayed = new List<int>();

    private void Update()
    {
        UpdateShop();
    }
    private void Start()
    {
        CreateShop();
    }
    void CreateShop()
    {
        for (int i = 0; i < shop.openedItems.Count; i++)
        {
            var obj = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
            var rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, rectTransform.localPosition.y, 0);

            var img = obj.transform.GetChild(0).GetComponentInChildren<Image>();
            img.sprite = shop.database.database.GetItem[shop.openedItems[i]].uiDisplay;
            img.color = new Color(1f, 1f, 1f);

            int price = shop.database.cost[shop.openedItems[i]];
            obj.GetComponentInChildren<TextMeshProUGUI>().text = price.ToString("n0");

            int tmpI = shop.openedItems[i];
            obj.GetComponentInChildren<Button>().onClick.AddListener( () => Buy(tmpI, price));

            displayed.Add(shop.openedItems[i]);
        }
    }

    void UpdateShop()
    {
        /*
        if (displayed.Count != shop.openedItems.Count)
        {
            
        }
        */
    }

    void Buy(int _id, int _price)
    {
        Debug.Log(_id.ToString() + " " + _price.ToString());
        var inv = inventory.GetComponent<Inventory>().inventory;
        if (Resources.gold >= _price)//inv.resources.gold >= _price)
        {
            inv.AddItem(new Item(inv.database.GetItem[_id]), 1);
            inv.resources.DiscountGold(_price);
        }
        else
        {
            Debug.Log("BOMJ");
        }
    }
}
