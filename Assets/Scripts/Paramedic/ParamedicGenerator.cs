using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ParamedicGenerator : MonoBehaviour
{
    public CurrentParamedicObject currentParamedicObject;

    public GameObject orderliesPanel;
    public Photo[] photos;
    public GameObject paramedicPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < currentParamedicObject.currentParamedics.Count; i++)
        {
            GameObject parent = CreateEmptyObject();
            CreatParamedicPrefab(parent);
            RenderParamedic(currentParamedicObject.currentParamedics[i].photo, parent.transform);
            SpawnParamedic(parent, currentParamedicObject.currentParamedics[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnApplicationQuit()
    {
        currentParamedicObject.DeleteAll();
    }


    private void GeneratParamedic(GameObject gameObject)
    {
        GameObject photoSO;
        NameDb nameDb = new NameDb();
        NormalRandom normal = new NormalRandom();
        var parentTransform = gameObject.transform;

        Paramedic paramedic = new Paramedic
        {
            Sex = (Sex)Random.Range(0, 2),
            Speed = normal.Next(1, 10)
        };

        photoSO = photos[Random.Range(0, photos.Length)].gameObject;

        if (paramedic.Sex == Sex.MALE)
        {
            List<string> names = nameDb.GetAllMaleName();
            List<string> surnames = nameDb.GetAllMaleSurname();
            List<string> patronymics = nameDb.GetAllMalePatronymic();
            paramedic.Name = names[Random.Range(0, names.Count)];
            paramedic.Surname = surnames[Random.Range(0, surnames.Count)];
            paramedic.Patronymic = patronymics[Random.Range(0, patronymics.Count)];
        }
        else
        {
            List<string> names = nameDb.GetAllFemaleName();
            List<string> surnames = nameDb.GetAllFemaleSurname();
            List<string> patronymics = nameDb.GetAllFemalePatronymic();
            paramedic.Name = names[Random.Range(0, names.Count)];
            paramedic.Surname = surnames[Random.Range(0, surnames.Count)];
            paramedic.Patronymic = patronymics[Random.Range(0, patronymics.Count)];
        }
        RenderParamedic(photoSO, parentTransform);

        ParamedicObject paramedicObject = CreateParamedicSO(paramedic, photoSO);
        currentParamedicObject.AddParamedic(paramedicObject);
        SpawnParamedic(gameObject, paramedic);
    }

    private void RenderParamedic(GameObject photoSO, Transform parentTransform)
    {
        Photo photo = Instantiate(photoSO.GetComponent<Photo>());
        photo.transform.SetParent(parentTransform.GetChild(0));
        photo.transform.position = new Vector3(photo.transform.position.x, photo.transform.position.y, 100);
        photo.transform.localPosition = new Vector3(0, 0, -1);
    }

    private void CreatParamedicPrefab(GameObject paramedic)
    {
        GameObject pref = Instantiate(paramedicPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        pref.transform.SetParent(paramedic.transform);
        pref.AddComponent<RectTransform>();
        RectTransform rt = pref.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.01f, 0.01f);
        rt.anchorMax = new Vector2(0.99f, 0.99f);
        rt.localScale = new Vector3(1, 1, 1);
        rt.offsetMin = new Vector2(0, 0);
        rt.offsetMax = new Vector2(0, 0);
        rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y, 0);
    }

    private void SpawnParamedic(GameObject parent, Paramedic newParamedic)
    {
        var gameObject = parent.transform.GetChild(0);
        Paramedic paramedic = gameObject.GetComponent<Paramedic>();
        paramedic.Sex = newParamedic.Sex;
        paramedic.Name = newParamedic.Name;
        paramedic.Surname = newParamedic.Surname;
        paramedic.Patronymic = newParamedic.Patronymic;
        paramedic.Speed = newParamedic.Speed;

        paramedic.photo = newParamedic.photo;
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

    private GameObject CreateEmptyObject()
    {
        GameObject gameObject = new GameObject();
        gameObject.name = "Paramedic";
        gameObject.AddComponent<CanvasRenderer>();
        gameObject.AddComponent<Image>();
        gameObject.AddComponent<Button>();
        gameObject.AddComponent<RectTransform>();
        gameObject.transform.SetParent(orderliesPanel.transform);
        RectTransform rt = gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(200, 200);
        rt.localScale = new Vector3(1, 1, 1);
        rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y, 0);
        return gameObject;
    }

    private ParamedicObject CreateParamedicSO(Paramedic paramedic, GameObject newPhoto)
    {
        ParamedicObject example = ScriptableObject.CreateInstance<ParamedicObject>();
        example.BecomeCurrent(paramedic, newPhoto);
        string path = $"Assets/Scriptable Object/Paramedic/{currentParamedicObject.currentParamedics.Count}.asset";
        AssetDatabase.CreateAsset(example, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();

        return example;
    }
}
