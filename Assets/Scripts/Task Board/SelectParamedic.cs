using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectParamedic : MonoBehaviour
{
    public GameObject selectedParamedicPanel;
    public GameObject background;
    private Button button;
    private GameObject paramedicObject;
    private Paramedic paramedic;
    private Photo photo;

    private void Start()
    {
        button = GetComponentInParent<Button>();
        paramedicObject = transform.GetChild(0).gameObject;
        paramedic = paramedicObject.GetComponent<Paramedic>();
        photo = paramedic.photo;

        button.onClick.AddListener(Select);
    }

    private void Select()
    {
        try
        {
            GameObject photo = selectedParamedicPanel.transform.GetChild(0).GetChild(0).gameObject;
            if(photo != null)
            {
                Destroy(photo);
            }
        }
        catch (UnityException e)
        {
            Debug.Log($"Paramedic is empty; Exception: {e.Message}");
        }
        RenderParamedic();
        DisplayInfo();

        selectedParamedicPanel.SetActive(true);
        background.SetActive(true);
    }

    private void RenderParamedic()
    {
        Paramedic selectedParamedic = selectedParamedicPanel.transform.GetChild(0).GetComponent<Paramedic>();
        selectedParamedic.photo = Instantiate(photo);
        selectedParamedic.photo.transform.SetParent(selectedParamedic.transform);
        selectedParamedic.photo.transform.position = new Vector3(photo.transform.position.x, photo.transform.position.y, 100);
        selectedParamedic.photo.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void DisplayInfo()
    {
        Transform info = selectedParamedicPanel.transform.GetChild(1);
        Transform characteristics = selectedParamedicPanel.transform.GetChild(2);

        TextMeshProUGUI sexUGUI = info.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nameUGUI = info.GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI surnameUGUI = info.GetChild(2).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI patronymicUGUI = info.GetChild(3).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI strengthUGUI = info.GetChild(4).GetComponent<TextMeshProUGUI>();

        TextMeshProUGUI eloquenceUGUI = characteristics.GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI willUGUI = characteristics.GetChild(2).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI physicalUGUI = characteristics.GetChild(3).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI empathyUGUI = characteristics.GetChild(4).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI additionalUGUI = characteristics.GetChild(5).GetComponent<TextMeshProUGUI>();

        nameUGUI.text = "Имя: " + paramedic.Name;
        surnameUGUI.text = "Фамилия: " + paramedic.Surname;
        patronymicUGUI.text = "Отчество: " + paramedic.Patronymic;
        sexUGUI.text = "Пол: " + (paramedic.Sex == Sex.MALE ? "М" : "Ж");
        strengthUGUI.text = "Скорость: " + paramedic.Speed.ToString();

        eloquenceUGUI.text = "Красноречие: " + paramedic.skills[0].Level;
        willUGUI.text = "Воля: " + paramedic.skills[1].Level;
        physicalUGUI.text = "Физподготовка: " + paramedic.skills[2].Level;
        empathyUGUI.text = "Эмпатия: " + paramedic.skills[3].Level;
        additionalUGUI.text = "Дополнительные: " + paramedic.skills[4].Level;
    }
}
