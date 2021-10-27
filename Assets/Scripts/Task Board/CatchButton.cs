using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchButton : MonoBehaviour
{
    [SerializeField]
    private ParamedicObject selectedParamedic;
    void Update()
    {
        if(string.IsNullOrEmpty(selectedParamedic.Name) && string.IsNullOrEmpty(selectedParamedic.Surname))
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
