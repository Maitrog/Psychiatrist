using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ParamedicCatcher paramedic;
    public PatientVictim patient;

    public PatientObject currentPatient;
    public ParamedicObject currentParamedic;

    public GameObject resultPanel;
    public GameObject gridPanel;

    private Color green = new Color(27, 147, 32);
    private Color red = new Color(157, 24, 27);
    public void Start()
    {
        NewGame();
    }

    private void ResetState()
    {
        patient.ResetState();
        paramedic.ResetState();
    }
    private void NewGame()
    {
        float spM = 1.0f - (float)(currentParamedic.Speed + 1 - currentPatient.Speed) / 16.0f;
        patient.speedMultiplaier = spM;
        patient.GetComponent<Movement>().speedMultiplaier = spM;
        paramedic.gameObject.SetActive(true);
        patient.gameObject.SetActive(true);
    }

    public void PatientVictimCatched(PatientVictim patient)
    {
        patient.gameObject.SetActive(false);
        GameOver();
    }

    private void GameOver()
    {
        bool isWin = false;
        HashSet<DiseaseType> posidivDisease = new HashSet<DiseaseType>();
        HashSet<DiseaseType> negativeDisease = new HashSet<DiseaseType>();

        foreach (Skill skill in currentParamedic.skills)
        {
            if (skill.Level == SkillLevel.LOWEST)
            {
                foreach (DiseaseType disease in skill.Diseases)
                    negativeDisease.Add(disease);
            }
            else
            {
                foreach (DiseaseType disease in skill.Diseases)
                    posidivDisease.Add(disease);
            }
        }
        negativeDisease = new HashSet<DiseaseType>(negativeDisease.Intersect(posidivDisease).ToList());
        posidivDisease = new HashSet<DiseaseType>(posidivDisease.Except(negativeDisease).ToList());
        foreach (DiseaseType disease in currentPatient.Diseases)
        {
            if (posidivDisease.Contains(disease))
                isWin = true;
        }

        paramedic.gameObject.SetActive(false);
        patient.gameObject.SetActive(false);

        Image background = resultPanel.GetComponent<Image>();
        TextMeshProUGUI text = resultPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (isWin)
        {
            background.color = Color.green;
            text.text = "YOU'R WIN";
        }
        else
        {
            background.color = Color.red;
            text.text = "YOU'R LOOOOOOOOOOOOOOOOOOOOOOOSE";
        }
        gridPanel.SetActive(false);
        resultPanel.SetActive(true);
        Debug.Log("Game Over");
    }
}
