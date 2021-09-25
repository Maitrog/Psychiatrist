using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacientGenerator : MonoBehaviour
{
    //добавлять данные в заранее созданный scriptable object CurrentPacient только в том случае, 
    //если квест на поимку завершен успешно, CurrentPacient можкет быть только один
    public bool canBecomeCurrent = true;
    public PacientSO pacientObject;


    public GameObject Panel;
    public Hair[] hairMalePrefabs;
    public Hair[] hairFemalePrefabs;
    public Face[] facePrefabs;
    public Body[] bodyPrefabs;
    public Pacient characterPrefab;

    private readonly List<Pacient> characters = new List<Pacient>();
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
        Pacient pacient = gameObject.GetComponent<Pacient>();

        pacient.Sex = (Sex)UnityEngine.Random.Range(0, 2);
        pacient.Age = UnityEngine.Random.Range(18, 75);
        pacient.MaxToxic = UnityEngine.Random.Range(10f, 30f);
        pacient.Strength = UnityEngine.Random.Range(0, 10);

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
        while (pacient.Characters.Count < 3)
        {
            pacient.Characters.Add((Characters)UnityEngine.Random.Range(0, values.Length));
        }

        if (pacient.Sex == Sex.MALE)
        {
            NameDb nameDb = gameObject.AddComponent<NameDb>();
            List<string> names = nameDb.GetAllMaleName();
            List<string> surnames = nameDb.GetAllMaleSurname();
            List<string> patronymics = nameDb.GetAllMalePatronymic();
            pacient.Name = names[UnityEngine.Random.Range(0, names.Count)];
            pacient.Surname = surnames[UnityEngine.Random.Range(0, surnames.Count)];
            pacient.Patronymic = patronymics[UnityEngine.Random.Range(0, patronymics.Count)];

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
            pacient.Name = names[UnityEngine.Random.Range(0, names.Count)];
            pacient.Surname = surnames[UnityEngine.Random.Range(0, surnames.Count)];
            pacient.Patronymic = patronymics[UnityEngine.Random.Range(0, patronymics.Count)];

            hairSO = hairFemalePrefabs[UnityEngine.Random.Range(0, hairMalePrefabs.Length)].gameObject;
            newHair = Instantiate(hairSO.GetComponent<Hair>());
            newHair.transform.SetParent(characterTransform);
            newHair.transform.position = newFace.transform.position + newFace.top.localPosition * scale - newHair.bottom.localPosition * scale;
            newHair.transform.localPosition = new Vector3(newHair.transform.localPosition.x, newHair.transform.localPosition.y, -1);
        }
        pacient.hair = newHair;
        pacient.face = newFace;
        pacient.body = newBody;

        characters.Add(pacient);
        
        //передаем данные в scriptable object, чтобы потом получить всю информациб о пациенте в любой другой сцене
        if (canBecomeCurrent)
        {
            pacientObject.BecomeCurrent(pacient, hairSO, faceSO, bodySO);
            canBecomeCurrent = false;
        }
        
    }
}
