using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    public Hair hair;
    public Face face;
    public Body body;

    public Sex Sex;
    public string Name;
    public string Surname;
    public string Patronymic;
    public int Age;
    public double MaxToxic;
    public double Toxic = 0;
    public double Strength;
    public HashSet<Characters> Characters = new HashSet<Characters>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum Characters
{
    ONE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
    EIGHT,
    NINE,
    TEN
}

public enum Sex
{
    MALE,
    FEMALE
}
