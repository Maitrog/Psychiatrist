using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BTNCHECK : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    public float AlphaThreshold = 0.001f;
    private void Start()
    {
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;

        AddEvent(this.gameObject, EventTriggerType.PointerEnter, delegate { OnEnter(this.gameObject); });
        AddEvent(this.gameObject, EventTriggerType.PointerExit, delegate { OnExit(this.gameObject); });
        AddEvent(this.gameObject, EventTriggerType.BeginDrag, delegate { OnDragStart(this.gameObject); });
        AddEvent(this.gameObject, EventTriggerType.EndDrag, delegate { OnDragEnd(this.gameObject); });
        AddEvent(this.gameObject, EventTriggerType.Drag, delegate { OnDrag(this.gameObject); });
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
        Debug.Log("Enter");
    }
    public void OnExit(GameObject obj)
    {
        Debug.Log("Exit");
    }
    public void OnDragStart(GameObject obj)
    {/*
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
        mouseItem.item = itemsDisplayed[obj];*/
        //Debug.Log(mouseItem.obj.GetComponent<Image>().);
    }

    public void OnDragEnd(GameObject obj)
    {/*
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
        mouseItem.item = null;*/
    }
    public void OnDrag(GameObject obj)
    {/*
        Debug.Log("Drag");
        if (mouseItem.obj != null)
        {
            RectTransform rectTransform = mouseItem.obj.GetComponent<RectTransform>();
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, mouseItem.obj.GetComponentInParent<Canvas>().worldCamera, out pos);
            rectTransform.position = rectTransform.TransformPoint(pos);//mouseItem.obj.transform.TransformPoint(pos);
            Debug.Log(pos);
        }*/
    }

    private void Update()
    {
        Click();
        //gameObject.GetComponent<BoxCollider2D>().size = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y);
    }

    public void Click()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(14);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(22);
                if (hit.transform.tag == "Slot")
                {
                    GameObject tmp = hit.transform.gameObject;
                    Debug.Log(tmp.tag);
                }
            }
        }
        */
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RectTransform rectTransform = this.GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, GetComponentInParent<Camera>(), out mousePos2D);
            Debug.Log(mousePos2D);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            Debug.Log(hit.collider);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.attachedRigidbody.AddForce(Vector2.up);
            }
        }
        */
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.transform.tag == "Slot")
            {
                Debug.Log("CLICKED ");
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.tag == "Slot") ;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.tag == "Slot") ;
            //Debug.Log("Down");
    }

}
