using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOn : MonoBehaviour
{
    [SerializeField]
    private Color green;
    private Color white = Color.white;

    [SerializeField]
    private ParamedicObject selectedParamedic;

    private Image myImage;

    [HideInInspector]
    public bool currentlySelected = false;

    void Start()
    {
        myImage = GetComponent<Image>();
        ClickMe();
    }

    public void ClickMe()
    {
        if (currentlySelected == false)
        {
            myImage.color = white;
            selectedParamedic.BecomeCurrent(new Paramedic(), null);
        }
        else
        {
            myImage.color = green;
            Paramedic paramedic = gameObject.transform.GetChild(0).GetComponent<Paramedic>();
            Debug.Log(paramedic.photo.GetComponent<Photo>().gameObject);
            selectedParamedic.BecomeCurrent(paramedic, paramedic.photo.GetComponent<Photo>().gameObject);
        }
    }
}
