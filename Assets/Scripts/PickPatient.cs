using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickPatient : MonoBehaviour
{
    public GameObject searchPanel;
    public GameObject pickedPatientPanel;

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
        Patient pickedPatient = DisplayPatient(patientNumber);
        DisplayInfo(pickedPatient);
        pickedPatientPanel.SetActive(true);
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
        strengthUGUI.text = "Сила: " + pickedPatient.Strength.ToString();
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
        pickedPatient.Strength = patient.Strength;
        pickedPatient.Characters = new List<Characters>(patient.Characters);

        return pickedPatient;
    }
}
