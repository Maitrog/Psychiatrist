using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickPatient : MonoBehaviour
{
    public GameObject searchPanel;
    public GameObject pickedPatientPanel;
    public CurrentParamedicObject currentParamedicObject;
    public GameObject orderliesPanel;
    public GameObject selectableParamedicPrefab;

    public void Pick(int patientNumber)
    {
        try
        {
            GameObject face = pickedPatientPanel.transform.GetChild(0).GetChild(0).gameObject;
            GameObject hair = pickedPatientPanel.transform.GetChild(0).GetChild(1).gameObject;
            GameObject body = pickedPatientPanel.transform.GetChild(0).GetChild(2).gameObject;
            if (face != null)
            {
                Destroy(face);
            }
            if(hair != null)
            {
                Destroy(hair);
            }
            if (body != null)
            {
                Destroy(body);
            }
        }
        catch (UnityException e)
        {
            Debug.Log($"Character is empty; Exception: {e.Message}");
        }
        for (int i = 0; i < orderliesPanel.transform.childCount; i++)
        {
            Destroy(orderliesPanel.transform.GetChild(i).gameObject);
        }
        Patient pickedPatient = DisplayPatient(patientNumber);
        DisplayInfo(pickedPatient);
        pickedPatientPanel.SetActive(true);

        for (int i = 0; i < currentParamedicObject.currentParamedics.Count; i++)
        {
            GameObject parent = CreatParamedicPrefab(orderliesPanel);
            RenderParamedic(currentParamedicObject.currentParamedics[i].photo, parent.transform);
            SpawnParamedic(parent, currentParamedicObject.currentParamedics[i]);
        }
    }

    private void DisplayInfo(Patient pickedPatient)
    {
        TextMeshProUGUI sexUGUI = pickedPatientPanel.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI ageUGUI = pickedPatientPanel.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nameUGUI = pickedPatientPanel.transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI surnameUGUI = pickedPatientPanel.transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI patronymicUGUI = pickedPatientPanel.transform.GetChild(1).GetChild(4).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI strengthUGUI = pickedPatientPanel.transform.GetChild(1).GetChild(5).GetComponent<TextMeshProUGUI>();

        nameUGUI.text = "Имя: " + pickedPatient.Name;
        surnameUGUI.text = "Фамилия: " + pickedPatient.Surname;
        patronymicUGUI.text = "Отчество: " + pickedPatient.Patronymic;
        ageUGUI.text = "Возраст: " + pickedPatient.Age.ToString();
        sexUGUI.text = "Пол: " + (pickedPatient.Sex == Sex.MALE ? "М" : "Ж");
        strengthUGUI.text = "Сила: " + pickedPatient.Speed.ToString();
    }

    private Patient DisplayPatient(int patientNumber)
    {
        float scale = ScreenSize.GetScreenToWorldWidth;
        GameObject gameObject = searchPanel.transform.GetChild(patientNumber).GetChild(0).gameObject;
        Patient patient = gameObject.GetComponent<Patient>();

        Patient pickedPatient = pickedPatientPanel.transform.GetChild(0).GetComponent<Patient>();
        pickedPatient.face = Instantiate(patient.face);
        pickedPatient.face.transform.SetParent(pickedPatient.transform);
        pickedPatient.face.transform.position = new Vector3(pickedPatient.face.transform.position.x, pickedPatient.face.transform.position.y, 100);
        pickedPatient.face.transform.localPosition = new Vector3(0, 75f, 0);

        pickedPatient.hair = Instantiate(patient.hair);
        pickedPatient.hair.transform.SetParent(pickedPatient.transform);
        pickedPatient.hair.transform.position = pickedPatient.face.transform.position + pickedPatient.face.top.localPosition * scale - pickedPatient.hair.bottom.localPosition * scale;
        pickedPatient.hair.transform.localPosition = new Vector3(pickedPatient.hair.transform.localPosition.x, pickedPatient.hair.transform.localPosition.y, -1);

        pickedPatient.body = Instantiate(patient.body);
        pickedPatient.body.transform.SetParent(pickedPatient.transform);
        pickedPatient.body.transform.position = pickedPatient.face.transform.position + pickedPatient.face.bottom.localPosition * scale - pickedPatient.body.top.localPosition * scale;
        pickedPatient.body.transform.localPosition = new Vector3(pickedPatient.body.transform.localPosition.x, pickedPatient.body.transform.localPosition.y, 0);

        pickedPatient.Sex = patient.Sex;
        pickedPatient.Name = patient.Name;
        pickedPatient.Surname = patient.Surname;
        pickedPatient.Patronymic = patient.Patronymic;
        pickedPatient.Age = patient.Age;
        pickedPatient.MaxToxic = patient.MaxToxic;
        pickedPatient.Toxic = patient.Toxic;
        pickedPatient.Speed = patient.Speed;
        pickedPatient.Characters = new List<Characters>(patient.Characters);

        return pickedPatient;
    }

    private GameObject CreatParamedicPrefab(GameObject paramedic)
    {
        GameObject pref = Instantiate(selectableParamedicPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        pref.transform.SetParent(paramedic.transform);
        pref.transform.localPosition = new Vector3(pref.transform.localPosition.x, pref.transform.localPosition.y, 0);
        pref.transform.localScale = new Vector3(1, 1, 1);
        return pref;
    }
    private void RenderParamedic(GameObject photoSO, Transform parentTransform)
    {
        Photo photo = Instantiate(photoSO.GetComponent<Photo>());
        photo.transform.SetParent(parentTransform.GetChild(0));
        photo.transform.position = new Vector3(photo.transform.position.x, photo.transform.position.y, 100);
        photo.transform.localPosition = new Vector3(0, 0, -3);
    }
    private void SpawnParamedic(GameObject parent, ParamedicObject paramedicObject)
    {
        var gameObject = parent.transform.GetChild(0);
        Paramedic paramedic = gameObject.GetComponent<Paramedic>();
        paramedic.Sex = paramedicObject.Sex;
        paramedic.Name = paramedicObject.Name;
        paramedic.Surname = paramedicObject.Surname;
        paramedic.Patronymic = paramedicObject.Patronymic;
        paramedic.Speed = paramedicObject.Speed;

        paramedic.photo = paramedicObject.photo.GetComponent<Photo>();
    }
}
