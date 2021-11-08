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

    public GameObject resultPanel;
    public GameObject gridPanel;

    [SerializeField]
    private int duration;
    private bool win;
    public void Start()
    {
        NewGame();
    }

    private void ResetState()
    {
        patient.ResetState();
        paramedic.ResetState();
        win = false;
    }
    private void NewGame()
    {
        win = false;
        float spM = 1.0f - (float)(StaticCurrentParamedics.SelectedParamedic.Speed + 1 - StaticCurrentPatients.SelectedPatient.Speed) / 16.0f;
        patient.speedMultiplaier = spM;
        patient.GetComponent<Movement>().speedMultiplaier = spM;
        patient.GetComponent<PatientVictimFrightened>().duration = duration;
        paramedic.gameObject.SetActive(true);
        patient.gameObject.SetActive(true);
        Invoke(nameof(IsWin), duration);
    }

    public void PatientVictimCatched(PatientVictim patient)
    {
        patient.gameObject.SetActive(false);
        GameOver();
    }

    private void GameOver()
    {
        HashSet<DiseaseType> posidivDisease = new HashSet<DiseaseType>();
        HashSet<DiseaseType> negativeDisease = new HashSet<DiseaseType>();

        foreach (Skill skill in StaticCurrentParamedics.SelectedParamedic.skills)
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
        foreach (DiseaseType disease in StaticCurrentPatients.SelectedPatient.Diseases)
        {
            if (posidivDisease.Contains(disease))
                win = true;
        }
        IsWin();
    }

    private void IsWin()
    {
        CancelInvoke();
        paramedic.gameObject.SetActive(false);
        patient.gameObject.SetActive(false);

        Image background = resultPanel.GetComponent<Image>();
        TextMeshProUGUI text = resultPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (win)
        {
            background.color = Color.green;
            text.text = "YOU'R WIN";
        }
        else
        {
            background.color = Color.red;
            text.text = "YOU'R LOOOOOOOOOOOOOOOOOOOOOOOSE";
            StaticCurrentPatients.SelectedPatient.Reset();
        }
        StaticCurrentParamedics.SelectedParamedic.Reset();
        gridPanel.SetActive(false);
        resultPanel.SetActive(true);
    }
}
