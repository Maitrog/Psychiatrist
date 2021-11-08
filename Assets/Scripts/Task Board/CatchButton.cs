using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchButton : MonoBehaviour
{
    void Update()
    {
        if(string.IsNullOrEmpty(StaticCurrentParamedics.SelectedParamedic.Name) && string.IsNullOrEmpty(StaticCurrentParamedics.SelectedParamedic.Surname))
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
