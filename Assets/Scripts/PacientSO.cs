using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pacient", menuName = "Pacient")]
public class PacientSO : ScriptableObject
{
    
    public GameObject hair;
    public GameObject face;
    public GameObject body;

    public Sex Sex;
    public string Name;
    public string Surname;
    public string Patronymic;
    public int Age;
    public double MaxToxic;
    public double Toxic;
    public double Strength;
    public HashSet<Characters> Characters;
    
    public void BecomeCurrent(Pacient pacient, GameObject newHair, GameObject newFace, GameObject newBody)
    {
        hair = newHair;
        face = newFace;
        body = newBody;

        Sex = pacient.Sex;
        Name = pacient.Name;
        Surname = pacient.Surname;
        Patronymic = pacient.Patronymic;
        Age = pacient.Age;
        MaxToxic = pacient.MaxToxic;
        Toxic = pacient.Toxic;
        Strength = pacient.Strength;

        Characters = new HashSet<Characters>(pacient.Characters);
    }
}