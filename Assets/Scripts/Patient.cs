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
    public List<Characters> Characters = new List<Characters>();

    void Start()
    {

    }
    void Update()
    {

    }
}

public enum Characters
{
    IRRITABILITY,
    ANXIETY,
    PARANOIA,
    HYPERACTIVITY,
    APATHY,
    FATIGUE,
    HYSTERICS,
    PANIC_ATTACKS,
    DELIRIUM,
    HALLUCINATIONS,
    SINCERITY,
    OPTIMISM,
    INCREASED_EMPATHY,
    INDIFFERENCE,
    ENVY,
    SUSPICIOUS,
    VANITY,
    SELFISHNESS,
    MAX

}
public enum Sex
{
    MALE,
    FEMALE
}