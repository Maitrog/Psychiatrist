using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickablesLayar;

    private GameObject selectedObject;
    void Update()
    {
        bool isTouch = false;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                isTouch = Input.GetTouch(0).phase == TouchPhase.Stationary;
            }
        }
        if (Input.GetMouseButtonDown(0) || isTouch)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            }
            RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction);

            if (raycastHit.collider != null)
            {
                ClickOn clickOnScript = raycastHit.collider.GetComponent<ClickOn>();
                if (selectedObject == raycastHit.collider.gameObject)
                {
                    selectedObject = null;
                    clickOnScript.currentlySelected = false;
                    clickOnScript.ClickMe();
                }
                else
                {
                    if (selectedObject != null)
                    {
                        selectedObject.GetComponent<ClickOn>().currentlySelected = false;
                        selectedObject.GetComponent<ClickOn>().ClickMe();
                        selectedObject = null;
                    }
                    selectedObject = raycastHit.collider.gameObject;
                    clickOnScript.currentlySelected = true;
                    clickOnScript.ClickMe();
                }
            }
        }
    }

}
