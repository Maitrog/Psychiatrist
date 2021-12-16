using UnityEngine;
using UnityEngine.UI;

public class UpdateToxicity : MonoBehaviour
{
    public Image bar;
    public float fill;
    public MethodsObject methods;
    public DrugsObject drugs;
    public PatientObject patient;
    public bool isAlive = true;
    public bool isSick = true;

    void Start()
    {
        Debug.Log("DISEASES:::");
        foreach (var c in patient.Diseases) 
            Debug.Log(c);
        fill = 0f;
    }
    void Update()
    {
        ToxicityUpdate();
    }
    private void ToxicityUpdate()
    {
        //проверка на наличие пациента
        float currentToxicity = 0f;
        int len = Mathf.Max(methods.container.items.Length, drugs.container.items.Length);
        for (int i = 0; i < len; i++)
        {
            if (methods.container.items[i].ID >= 0)
            {
                currentToxicity += methods.container.items[i].amount * methods.container.items[i].item.toxicity;
            }

            if (drugs.container.items[i].ID >= 0)
            {
                currentToxicity += drugs.container.items[i].amount * drugs.container.items[i].item.toxicity;
            }
        }

        if (currentToxicity >= patient.MaxToxic)
            isAlive = false;
        else
            isAlive = true;

        bar.fillAmount = currentToxicity / (float)patient.MaxToxic;
    }
    
    public void Submit()
    {
        foreach (var c in patient.Diseases)
            Debug.Log(c);

        if (methods.container.items[0].ID >= 0 || drugs.container.items[0].ID >= 0)
        {
            int len = Mathf.Max(methods.container.items.Length, drugs.container.items.Length);
            for (int i = 0; i < len; i++)
            {
                if (methods.container.items[i].ID >= 0) 
                {
                    if (patient.Diseases.Contains(methods.container.items[i].item.character))
                    {
                        patient.Diseases.Remove(methods.container.items[i].item.character);
                        Debug.Log(methods.container.items[i].item.character);
                    }
                }

                if (drugs.container.items[i].ID >= 0)
                {
                    if (patient.Diseases.Contains(drugs.container.items[i].item.character))
                    {
                        patient.Diseases.Remove(drugs.container.items[i].item.character);
                        Debug.Log(drugs.container.items[i].item.character);
                    }
                }

                methods.container.items[i].UpdateSlot(-1, null, 0);
                drugs.container.items[i].UpdateSlot(-1, null, 0);
            }
        }
    }
}
