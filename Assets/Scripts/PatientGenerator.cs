using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientGenerator : MonoBehaviour
{
    //добавлять данные в заранее созданный scriptable object CurrentPacient только в том случае, 
    //если квест на поимку завершен успешно, CurrentPacient можкет быть только один
    public bool canBecomeCurrent = true;
    public PatientSO pacientObject;


    public GameObject Panel;
    public Hair[] hairMalePrefabs;
    public Hair[] hairFemalePrefabs;
    public Face[] facePrefabs;
    public Body[] bodyPrefabs;
    public Patient characterPrefab;

    private readonly List<Patient> characters = new List<Patient>();
    // Start is called before the first frame update
    void Start()
    {
        while (characters.Count < 4)
        {
            SpawnCharacter(characters.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnCharacter(int index)
    {
        //для ScriptableObject
        GameObject faceSO;
        GameObject hairSO;
        GameObject bodySO;



        float scale = ScreenSize.GetScreenToWorldWidth;
        var characterTransform = Panel.transform.GetChild(index);
        var gameObject = characterTransform.gameObject;
        Hair newHair;
        Patient patient = gameObject.GetComponent<Patient>();

        patient.Sex = (Sex)UnityEngine.Random.Range(0, 2);
        patient.Age = UnityEngine.Random.Range(18, 75);
        patient.MaxToxic = UnityEngine.Random.Range(10f, 30f);
        patient.Strength = UnityEngine.Random.Range(0, 10);

        faceSO = facePrefabs[UnityEngine.Random.Range(0, facePrefabs.Length)].gameObject;
        Face newFace = Instantiate(faceSO.GetComponent<Face>());
        newFace.transform.SetParent(characterTransform);
        newFace.transform.position = new Vector3(newFace.transform.position.x, newFace.transform.position.y, 100);
        newFace.transform.localPosition = new Vector3(0, 75.0f, 0);

        bodySO = bodyPrefabs[UnityEngine.Random.Range(0, bodyPrefabs.Length)].gameObject;
        Body newBody = Instantiate(bodySO.GetComponent<Body>());
        newBody.transform.SetParent(characterTransform);
        newBody.transform.position = newFace.transform.position + newFace.bottom.localPosition * scale - newBody.top.localPosition * scale;
        newBody.transform.localPosition = new Vector3(newBody.transform.localPosition.x, newBody.transform.localPosition.y, 0);

        Array values = Enum.GetValues(typeof(Characters));
        while (patient.Characters.Count < 3)
        {
            patient.Characters.Add((Characters)UnityEngine.Random.Range(0, values.Length));
        }

        if (patient.Sex == Sex.MALE)
        {
            NameDb nameDb = gameObject.AddComponent<NameDb>();
            List<string> names = nameDb.GetAllMaleName();
            List<string> surnames = nameDb.GetAllMaleSurname();
            List<string> patronymics = nameDb.GetAllMalePatronymic();
            patient.Name = names[UnityEngine.Random.Range(0, names.Count)];
            patient.Surname = surnames[UnityEngine.Random.Range(0, surnames.Count)];
            patient.Patronymic = patronymics[UnityEngine.Random.Range(0, patronymics.Count)];

            hairSO = hairMalePrefabs[UnityEngine.Random.Range(0, hairMalePrefabs.Length)].gameObject;
            newHair = Instantiate(hairSO.GetComponent<Hair>());
            newHair.transform.SetParent(characterTransform);
            newHair.transform.position = newFace.transform.position + newFace.top.localPosition * scale - newHair.bottom.localPosition * scale;
            newHair.transform.localPosition = new Vector3(newHair.transform.localPosition.x, newHair.transform.localPosition.y, -1);
        }
        else
        {
            NameDb nameDb = gameObject.AddComponent<NameDb>();
            List<string> names = nameDb.GetAllFemaleName();
            List<string> surnames = nameDb.GetAllFemaleSurname();
            List<string> patronymics = nameDb.GetAllFemalePatronymic();
            patient.Name = names[UnityEngine.Random.Range(0, names.Count)];
            patient.Surname = surnames[UnityEngine.Random.Range(0, surnames.Count)];
            patient.Patronymic = patronymics[UnityEngine.Random.Range(0, patronymics.Count)];

            hairSO = hairFemalePrefabs[UnityEngine.Random.Range(0, hairMalePrefabs.Length)].gameObject;
            newHair = Instantiate(hairSO.GetComponent<Hair>());
            newHair.transform.SetParent(characterTransform);
            newHair.transform.position = newFace.transform.position + newFace.top.localPosition * scale - newHair.bottom.localPosition * scale;
            newHair.transform.localPosition = new Vector3(newHair.transform.localPosition.x, newHair.transform.localPosition.y, -1);
        }
        patient.hair = newHair;
        patient.face = newFace;
        patient.body = newBody;

        characters.Add(patient);
        
        //передаем данные в scriptable object, чтобы потом получить всю информациб о пациенте в любой другой сцене
        if (canBecomeCurrent)
        {
            pacientObject.BecomeCurrent(patient, hairSO, faceSO, bodySO);
            canBecomeCurrent = false;
        }
        
    }
}
