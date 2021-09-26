using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class DisplayMethods : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public MethodsObject inventory;
    Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
    private bool inSlot = false;
    GameObject clickObj;
    public InventoryObject playerInventory;

    void Start()
    {
        CreateSlots();
    }

    void Update()
    {
        UpdateSlots();
        MouseClicked();
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
            else
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
        inSlot = true;
        clickObj = obj;
        Debug.Log("Enter");
    }
    public void OnExit(GameObject obj)
    {
        inSlot= false;
        clickObj = null;
        Debug.Log("Exit");
    }
    private void MouseClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (inSlot)
            {
                Debug.Log(clickObj.name);
                InventorySlot slot = itemsDisplayed[clickObj];
                if (slot.amount > 0)
                {
                    inventory.AddItem(slot.item, -1);
                    playerInventory.AddItem(slot.item, 1);
                }
            }
        }
    }
}
