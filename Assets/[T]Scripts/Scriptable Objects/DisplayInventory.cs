using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayInventory : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();
    //public GameObject shop;
    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEMS;
    public int Y_SPACE_BETWEEN_ITEMS;
    public int NUMBER_OF_COLUMNS;
    Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
    bool inSLot = false;
    public bool inTreatment;
    private GameObject clickObj;

    public MethodsObject methods;
    public DrugsObject drugs;

    void Start()
    {
        CreateSlots();
        //AwakeResources();
    }

    void Update()
    {
        UpdateSlots();
        if (inTreatment) MouseClicked();
    }
    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
        {
            if (_slot.Value.ID >= 0 && _slot.Value.amount > 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.Id].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount.ToString("n0");
            }
            else //if (_slot.Value.ID != -1)
            {
                if (_slot.Value.amount <= 0)
                    _slot.Value.UpdateSlot(-1, null, 0);
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventoryPrefab.GetComponentInChildren<Image>().sprite;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color32(195, 126, 126, 255);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    public void CreateSlots()
    {
        //for (int i = 0; i < inventory.container.items.Count; i++)
        //{
        //    InventorySlot slot = inventory.container.items[i];

        //    var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
        //    obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].uiDisplay;
        //    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        //    obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
        //    itemsDisplayed.Add(slot, obj);
        //}
        /*
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.container.items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, this.transform.GetChild(0).transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });


            itemsDisplayed.Add(obj, inventory.container.items[i]);
        }
        */
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        var img = this.transform.GetChild(0);
        int i = 0;
        foreach (Transform obj in img)
        {
            if (obj.tag == "Slot")
            {
                AddEvent(obj.gameObject, EventTriggerType.PointerEnter, delegate { OnEnter(obj.gameObject); });
                AddEvent(obj.gameObject, EventTriggerType.PointerExit, delegate { OnExit(obj.gameObject); });
                itemsDisplayed.Add(obj.gameObject, inventory.container.items[i]);
                i++;
            }
        }
    }
    
    private void MouseClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (inSLot) {
                Debug.Log(clickObj.name);
                InventorySlot slot = itemsDisplayed[clickObj];
                if (slot.amount > 0)
                {
                    inventory.AddItem(slot.item, -1);
                    if (slot.item.type == ItemType.Methods)
                    {
                        Debug.Log("methods");
                        methods.AddItem(slot.item, 1);
                    }
                    else if (slot.item.type == ItemType.Tablets)
                    {
                        Debug.Log("tablets");
                        drugs.AddItem(slot.item, 1);
                    }
                }
            }
        }
    }
    
    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        inSLot = true;
        clickObj = obj;
        Debug.Log("Enter");
        /*
        mouseItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
            mouseItem.hoverItem = itemsDisplayed[obj];
        */
    }
    public void OnExit(GameObject obj)
    {
        inSLot = false;
        clickObj = null;
        Debug.Log("Exit");
        mouseItem.hoverObj = null;
        mouseItem.hoverItem = null;
    }
    
    //public void OnDragStart(GameObject obj)
    //{
    //    Debug.Log("Drag start");
    //    //var mouseObject = new GameObject();
    //    //var rt = mouseObject.AddComponent<RectTransform>();
    //    //rt.sizeDelta = new Vector2(50, 50);
    //    var mouseObject = Instantiate(obj, Vector3.zero, Quaternion.identity, transform);
    //    //mouseObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
    //    //mouseObject.transform.SetParent(transform.parent);
    //    if (itemsDisplayed[obj].ID >= 0)
    //    {
    //        var img = mouseObject.GetComponentInChildren<Image>();
    //        img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
    //        img.raycastTarget = false;
    //    }

    //    mouseItem.obj = mouseObject;
    //    mouseItem.item = itemsDisplayed[obj];
    //    /*
    //    mouseItem.hoverObj = obj;
    //    if (itemsDisplayed.ContainsKey(obj))
    //        mouseItem.hoverItem = itemsDisplayed[obj];
    //    */
    //}
    
    
    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(1, 1);
        mouseObject.transform.SetParent(transform.parent);
        if (itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
            img.enabled = true;
            img.raycastTarget = false;
        }
        mouseItem.obj = mouseObject;
        mouseItem.item = itemsDisplayed[obj];
        //Debug.Log(mouseItem.obj.GetComponent<Image>().);
    }
    
    public void OnDragEnd(GameObject obj)
    {
        Debug.Log("Drag end");
        if (mouseItem.hoverObj != null)
        {
            inventory.MoveItem(itemsDisplayed[obj], itemsDisplayed[mouseItem.hoverObj]);
            Debug.Log("move");
        }
        else
        {
            inventory.RemoveItem(itemsDisplayed[obj].item);
            Debug.Log("remove");
        }
        Destroy(mouseItem.obj);
        mouseItem.item = null;
    }
    /*
    public void OnDrag(GameObject obj)
    {
        if (mouseItem.obj != null)
        {
            Debug.Log(Input.mousePosition);
            mouseItem.obj.GetComponent<RectTransform>().position = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseItem.obj.GetComponent<RectTransform>().position).normalized;
        }
    }
    */
    public void OnDrag(GameObject obj)
    {
        Debug.Log("Drag");
        if (mouseItem.obj != null)
        {
            RectTransform rectTransform = mouseItem.obj.GetComponent<RectTransform>();
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, mouseItem.obj.GetComponentInParent<Canvas>().worldCamera, out pos);
            rectTransform.position = rectTransform.TransformPoint(pos);//mouseItem.obj.transform.TransformPoint(pos);
            Debug.Log(pos);
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_COLUMNS)),Y_START + ((-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMNS))), 0f);
    }
}

public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public InventorySlot hoverItem;
    public GameObject hoverObj;
}
