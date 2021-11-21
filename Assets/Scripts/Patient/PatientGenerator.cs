using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientGenerator : MonoBehaviour
{
    public CurrentTargetsObject currentTargetsSO;

    public GameObject searchPanel;
    public Hair[] hairMalePrefabs;
    public Hair[] hairFemalePrefabs;
    public Face[] facePrefabs;

    private void Awake()
    {
        for (int i = 0; i < StaticCurrentPatients.CurrentPatients.Count; i++)
        {
            Patient patient = new Patient
            {
                Age = StaticCurrentPatients.CurrentPatients[i].Age,
                Name = StaticCurrentPatients.CurrentPatients[i].Name,
                Surname = StaticCurrentPatients.CurrentPatients[i].Surname,
                Patronymic = StaticCurrentPatients.CurrentPatients[i].Patronymic,
                Sex = StaticCurrentPatients.CurrentPatients[i].Sex,
                MaxToxic = StaticCurrentPatients.CurrentPatients[i].MaxToxic,
                Toxic = StaticCurrentPatients.CurrentPatients[i].Toxic,
                Speed = StaticCurrentPatients.CurrentPatients[i].Speed
            };
            currentTargetsSO.AddPatient(i, patient, StaticCurrentPatients.CurrentPatients[i].hair, StaticCurrentPatients.CurrentPatients[i].face);
        }
    }
    void Start()
    {
        for (int i = 0; i < currentTargetsSO.isReady.Count; i++)
        {
            if (currentTargetsSO.isReady[i])
            {
                GeneratePatient(i);
            }
            else
            {
                RenderPatient(i, currentTargetsSO.currentTarget[i].face, currentTargetsSO.currentTarget[i].hair);
                SpawnPatient(i, currentTargetsSO.currentTarget[i]);
            }
        }
        StaticCurrentPatients.CurrentPatients = currentTargetsSO.currentTarget;
    }

    void Update()
    {
        if (currentTargetsSO.Count < 4)
        {
            for (int i = 0; i < currentTargetsSO.isReady.Count; i++)
            {
                if (currentTargetsSO.isReady[i])
                {
                    GeneratePatient(i);
                }
            }
        }
    }

    private void GeneratePatient(int index)
    {
        int maxDiseases = 2;
        GameObject faceSO;
        GameObject hairSO;
        NameDb nameDb = new NameDb();
        NormalRandom normal = new NormalRandom();
        Patient patient = new Patient
        {
            Sex = (Sex)UnityEngine.Random.Range(0, 2),
            Age = UnityEngine.Random.Range(18, 75),
            MaxToxic = normal.NextDouble(10f, 30f),
            Speed = normal.Next(1, 4)
        };

        faceSO = facePrefabs[UnityEngine.Random.Range(0, facePrefabs.Length)].gameObject;

        Array values = Enum.GetValues(typeof(DiseaseType));
        HashSet<DiseaseType> diseases = new HashSet<DiseaseType>();
        while (diseases.Count < maxDiseases)
        {
            DiseaseType disease = (DiseaseType)UnityEngine.Random.Range(0, values.Length - 1);
            if (disease == DiseaseType.BIPOLAR_DISORDER)
            {
                maxDiseases = 3;
                continue;
            }
            diseases.Add(disease);
        }

        foreach (DiseaseType type in diseases)
        {
            patient.Diseases.Add(type);
        }

        if (patient.Sex == Sex.MALE)
        {
            List<string> names = nameDb.GetAllMaleName();
            List<string> surnames = nameDb.GetAllMaleSurname();
            List<string> patronymics = nameDb.GetAllMalePatronymic();
            patient.Name = names[UnityEngine.Random.Range(0, names.Count)];
            patient.Surname = surnames[UnityEngine.Random.Range(0, surnames.Count)];
            patient.Patronymic = patronymics[UnityEngine.Random.Range(0, patronymics.Count)];

            hairSO = hairMalePrefabs[UnityEngine.Random.Range(0, hairMalePrefabs.Length)].gameObject;
        }
        else
        {
            List<string> names = nameDb.GetAllFemaleName();
            List<string> surnames = nameDb.GetAllFemaleSurname();
            List<string> patronymics = nameDb.GetAllFemalePatronymic();
            patient.Name = names[UnityEngine.Random.Range(0, names.Count)];
            patient.Surname = surnames[UnityEngine.Random.Range(0, surnames.Count)];
            patient.Patronymic = patronymics[UnityEngine.Random.Range(0, patronymics.Count)];

            hairSO = hairFemalePrefabs[UnityEngine.Random.Range(0, hairFemalePrefabs.Length)].gameObject;
        }

        Patient spawnedPatient = RenderPatient(index, faceSO, hairSO);

        patient.hair = spawnedPatient.hair;
        patient.face = spawnedPatient.face;

        SpawnPatient(index, patient);
        currentTargetsSO.AddPatient(index, patient, hairSO, faceSO);
    }

    private Patient RenderPatient(int index, GameObject faceSO, GameObject hairSO)
    {
        float scale = ScreenSize.GetScreenToWorldWidth * 0.8f;
        var parentTransform = searchPanel.transform.GetChild(index).GetChild(0);

        Face newFace = Instantiate(faceSO.GetComponent<Face>());
        newFace.transform.SetParent(parentTransform);
        newFace.transform.position = new Vector3(newFace.transform.position.x, newFace.transform.position.y, 100);
        newFace.transform.localPosition = new Vector3(0, -5f, 0);

        Hair newHair = Instantiate(hairSO.GetComponent<Hair>());
        newHair.transform.SetParent(parentTransform);
        newHair.transform.position = newFace.transform.position + newFace.top.localPosition * scale - newHair.bottom.localPosition * scale;
        newHair.transform.localPosition = new Vector3(newHair.transform.localPosition.x, newHair.transform.localPosition.y, -1);

        return new Patient() { hair = newHair, face = newFace };
    }

    private void SpawnPatient(int index, Patient _patient)
    {
        var characterTransform = searchPanel.transform.GetChild(index).GetChild(0);
        var gameObject = characterTransform.gameObject;
        Patient patient = gameObject.GetComponent<Patient>();
        patient.Age = _patient.Age;
        patient.Sex = _patient.Sex;
        patient.Name = _patient.Name;
        patient.Surname = _patient.Surname;
        patient.Patronymic = _patient.Patronymic;
        patient.MaxToxic = _patient.MaxToxic;
        patient.Speed = _patient.Speed;
        patient.Toxic = _patient.Toxic;
        patient.Diseases = new List<DiseaseType>(_patient.Diseases);

        patient.hair = _patient.hair;
        patient.face = _patient.face;
    }

    private void SpawnPatient(int index, PatientObject _patient)
    {
        var characterTransform = searchPanel.transform.GetChild(index).GetChild(0);
        var gameObject = characterTransform.gameObject;
        Patient patient = gameObject.GetComponent<Patient>();
        patient.Age = _patient.Age;
        patient.Sex = _patient.Sex;
        patient.Name = _patient.Name;
        patient.Surname = _patient.Surname;
        patient.Patronymic = _patient.Patronymic;
        patient.MaxToxic = _patient.MaxToxic;
        patient.Speed = _patient.Speed;
        patient.Toxic = _patient.Toxic;
        patient.Diseases = new List<DiseaseType>(_patient.Diseases);

        patient.hair = _patient.hair.GetComponent<Hair>();
        patient.face = _patient.face.GetComponent<Face>();
    }
}
