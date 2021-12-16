using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextManager : MonoBehaviour
{
    public Button but1;
    public Button but2;
    public Button but3;
    public Button but4;
    public Text Text1;
    public Text Text2;
    public Text Text3;
    public Text Text4;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image[] ImageMas=new Image[4];
    public Text DialogText;
    public Text[] DialogTexts;
    Context context;
    public static List<Question> questions;
     Button[] but_mas;
    public static int k = 0;
    int[] nums = new int[] { 14, 15, 17, 18, 1, 2 };
    static public string[] buttonTexts=new string[4];

    void clearTextBoxes()
    {
        for (int i = 0; i < 4; i++)
        {
            ImageMas[i].enabled = false;
        }
    }



    void Start()
    {

        List<Deviation> deviations = new List<Deviation>();
        try {
        ArrayList numsBuff = new ArrayList();

        List<DiseaseType> diseasesTypes = StaticCurrentPatients.SelectedPatient.Diseases;
        foreach (DiseaseType i in diseasesTypes)
        {
            deviations.AddRange(Disease.GetDisease(i).Deviations);
                Debug.Log("disise");
        }
        Debug.Log(deviations.Count);
        foreach (Deviation i in deviations)
        {
            Debug.Log("abc"+i);
        }
        IQueryable<Deviation> deviationsDist= deviations.AsQueryable().Distinct();
        deviations = deviationsDist.ToList();

        Debug.Log(deviations.Count);
        
            Debug.Log("OKEEEEEEEEEEEEEEYYY");
        }
        catch (Exception e)
        {
            Debug.Log("errot");
        }

        ImageMasCreate();
        clearTextBoxes();
        but_mas= new Button[4];
        but_mas[0] = but1;
        but_mas[1] = but2;
        but_mas[2] = but3;
        but_mas[3] = but4;

        DialogTexts= new Text[4];
        DialogTexts[0] = Text1;
        DialogTexts[1] = Text2;
        DialogTexts[2] = Text3;
        DialogTexts[3] = Text4;

        if (StaticClassSave.saveFlag)
        {
            //Debug.Log(k);
            k = StaticClassSave.charactNum;
            //Debug.Log(k);
            questions = StaticClassSave.questions;
        }
            //Debug.Log(k);


        int N = 6;
        context = new Context();

        int[] nums1 = new int[deviations.Count];
        for (int i = 0; i < deviations.Count; i++)
        {
            
            nums1[i] = context.characteristics.Find(x => ((int)x.Characters) == (int)deviations[i]).id;
            Debug.Log(nums1[i]);
        }
        nums = nums1;
        N = nums.Length;
        questions = new List<Question>();
        for (int i = 0; i < N; i++)
        {
            questions.AddRange(context.questions.FindAll(x => x.characteristicId == nums[i]));
        }

        if (k != N + 1) { 
            questions = DialogueSay.ButtonTextCreate(context, questions, 0, nums,k, DialogTexts, but_mas);
            if (k == 0) k++;
        }
        else
        {
            but1.GetComponentInChildren<Text>().text = "...";
            but2.GetComponentInChildren<Text>().text = "...";
            but3.GetComponentInChildren<Text>().text = "...";
            but4.GetComponentInChildren<Text>().text = "...";
        }

        if (StaticClassSave.saveFlag)
        {

            but1.GetComponentInChildren<Text>().text = buttonTexts[0];
            but2.GetComponentInChildren<Text>().text = buttonTexts[1];
            but3.GetComponentInChildren<Text>().text = buttonTexts[2];
            but4.GetComponentInChildren<Text>().text = buttonTexts[3];

        }

        
        Dialoges.CurrenrPages = System.Math.Max(0, Dialoges.CurrenrPages-1);
        Refresh();
    }

    void ImageMasCreate()
    {
        ImageMas[0] = image1;
        ImageMas[1] = image2;
        ImageMas[2] = image3;
        ImageMas[3] = image4;
    }

    public void TextBoxSet()
    {
        clearTextBoxes();
        for(int i = 0; i < 4; i++)
        {
            if (DialogTexts[i].text!="")
            {
                ImageMas[i].enabled = true;
            }
        }

        /*
        if (k != 1)
        {
            for (int i = 0; i < (k) % 2+1; i++)
            {
                ImageMas[2*i].enabled = true;
                ImageMas[2*i+1].enabled = true;
            }
        }
        */
    }

    public void Refresh()
    {

        buttonTexts[0]=but1.GetComponentInChildren<Text>().text;
        buttonTexts[1]=but2.GetComponentInChildren<Text>().text;
        buttonTexts[2]=but3.GetComponentInChildren<Text>().text;
        buttonTexts[3]=but4.GetComponentInChildren<Text>().text;

        buttonTexts.CopyTo(StaticClassSave.ButTexts, 0);
        Dialoges.UpdateSave();
        clearTextBoxes();
        TextBoxSet();
        
    }

    public void button1()
    {
       
        
        if (but1.GetComponentInChildren<Text>().text != "...")
        {
            //
            //questions = DialogueSay.ButtonTextCreate(context, questions, 1, nums, k, DialogTexts, but_mas);
            //questions = DialogueSay.ButtonTextCreate(context, questions, 1, nums, k, Dialoges.Replices, but_mas);
            questions = DialogueSay.ButtonTextCreate(context, questions, 1, nums, k, Dialoges.Replices, DialogTexts, but_mas);
            k++;
        } 
        Dialoges.ChangePageToCurrent(ImageMas);
        Refresh();
        //Dialoges.UpdateSave();
    }

     public void button2()
    {
        

        if (but2.GetComponentInChildren<Text>().text != "...") { 
        questions = DialogueSay.ButtonTextCreate(context, questions, 2, nums, k, Dialoges.Replices, DialogTexts, but_mas);
        k++;
        }
        Dialoges.ChangePageToCurrent(ImageMas);
        Refresh();
        //Dialoges.UpdateSave();
    }

     public void button3()
    {
        

        if (but3.GetComponentInChildren<Text>().text != "...")
        {
            //questions = DialogueSay.ButtonTextCreate(context, questions, 3, nums, k, DialogTexts, but_mas);
            questions = DialogueSay.ButtonTextCreate(context, questions, 3, nums, k, Dialoges.Replices, DialogTexts, but_mas);
            k++;
        }
        Dialoges.ChangePageToCurrent(ImageMas);
        Refresh();
        //Dialoges.UpdateSave();
    }

     public void button4()
    {
        

        if (but4.GetComponentInChildren<Text>().text != "...")
        {
            //questions = DialogueSay.ButtonTextCreate(context, questions, 4, nums, k, DialogTexts, but_mas);
            questions = DialogueSay.ButtonTextCreate(context, questions, 4, nums, k, Dialoges.Replices, DialogTexts, but_mas);
            k++;
        }
        Dialoges.ChangePageToCurrent(ImageMas);
        Refresh();
        //Dialoges.UpdateSave();
    }
}
