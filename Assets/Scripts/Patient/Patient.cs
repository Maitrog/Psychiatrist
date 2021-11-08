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
    public double Speed;
    public List<DiseaseType> Diseases = new List<DiseaseType>();
}

public class Disease
{
    public DiseaseType Type { get; private set; }
    public List<Deviation> Deviations { get; private set; }
    private Disease() { }

    public static Disease GetDisease(DiseaseType type)
    {
        switch (type)
        {
            case DiseaseType.ANGER:
                return new Disease { Type = DiseaseType.ANGER, Deviations = new List<Deviation> { Deviation.UNCONTROLLED_AGGRESSION, Deviation.LUST_FOR_VIOLENCE } };
            case DiseaseType.BIPOLAR_DISORDER:
                return new Disease { Type = DiseaseType.BIPOLAR_DISORDER, Deviations = new List<Deviation>() };
            case DiseaseType.DEPRESSION:
                return new Disease { Type = DiseaseType.DEPRESSION, Deviations = new List<Deviation> { Deviation.APATHY, Deviation.FATIGUE, Deviation.UNCERTAINTY, Deviation.SELF_FLAGELLATION } };
            case DiseaseType.GREED:
                return new Disease { Type = DiseaseType.GREED, Deviations = new List<Deviation> { Deviation.KLEPTOMANIA, Deviation.SELFISHNESS, Deviation.AVARICE } };
            case DiseaseType.HALLUCINATIONS:
                return new Disease { Type = DiseaseType.HALLUCINATIONS, Deviations = new List<Deviation>() };
            case DiseaseType.PARANOIA:
                return new Disease { Type = DiseaseType.PARANOIA, Deviations = new List<Deviation> { Deviation.ANXIETY, Deviation.SUSPICIOUS, Deviation.PANIC_ATTACKS, Deviation.INSOMNIA } };
            case DiseaseType.PSYCHOSIS:
                return new Disease { Type = DiseaseType.PSYCHOSIS, Deviations = new List<Deviation> { Deviation.HYSTERICS, Deviation.SELF_HARM, Deviation.IRRITABILITY, Deviation.INSOMNIA } };
            case DiseaseType.RAVE:
                return new Disease { Type = DiseaseType.RAVE, Deviations = new List<Deviation>() };
            case DiseaseType.SELF_TORTURE:
                return new Disease { Type = DiseaseType.SELF_TORTURE, Deviations = new List<Deviation> { Deviation.MASOCHISM, Deviation.SELF_HARM, Deviation.SELF_FLAGELLATION } };
            case DiseaseType.SOCIOPATHY:
                return new Disease { Type = DiseaseType.SOCIOPATHY, Deviations = new List<Deviation> { Deviation.LACK_OF_EMOTION, Deviation.SELFISHNESS, Deviation.MANIPULATION } };
            case DiseaseType.VANITY:
                return new Disease { Type = DiseaseType.VANITY, Deviations = new List<Deviation> { Deviation.PRIDE, Deviation.SELFISHNESS, Deviation.MEGALOMANIA } };
            default:
                return new Disease { Type = DiseaseType.MAX };
        }
    }
}
[System.Serializable]
public enum Deviation
{
    ANXIETY,
    APATHY,
    AVARICE,
    FATIGUE,
    HYSTERICS,
    INSOMNIA,
    IRRITABILITY,
    KLEPTOMANIA,
    LACK_OF_EMOTION,
    LUST_FOR_VIOLENCE,
    MANIPULATION,
    MASOCHISM,
    MEGALOMANIA,
    PRIDE,
    PANIC_ATTACKS,
    SELF_FLAGELLATION,
    SELF_HARM,
    SELFISHNESS,
    SUSPICIOUS,
    UNCERTAINTY,
    UNCONTROLLED_AGGRESSION
}
public enum Sex
{
    MALE,
    FEMALE
}

[System.Serializable]
public enum DiseaseType
{
    ANGER,
    BIPOLAR_DISORDER,
    DEPRESSION,
    GREED,
    HALLUCINATIONS,
    PARANOIA,
    PSYCHOSIS,
    RAVE,
    SELF_TORTURE,
    SOCIOPATHY,
    VANITY,
    MAX
}