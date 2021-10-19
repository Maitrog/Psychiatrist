using System.Collections;
using System.Collections.Generic;
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
    public Text Text5;
    public Text Text6;
    public Text Text7;
    public Text Text8;
    public Text DialogText;
    public Text[] DialogTexts;
    Context context;
     List<Question> questions;
     Button[] but_mas;
     int k = 0;
     int[] nums = new int[] {1, 23,  27, 19 };


    void Start()
    {
        but_mas= new Button[4];
        but_mas[0] = but1;
        but_mas[1] = but2;
        but_mas[2] = but3;
        but_mas[3] = but4;

        DialogTexts= new Text[8];
        DialogTexts[0] = Text1;
        DialogTexts[1] = Text2;
        DialogTexts[2] = Text3;
        DialogTexts[3] = Text4;
        DialogTexts[4] = Text5;
        DialogTexts[5] = Text6;
        DialogTexts[6] = Text7;
        DialogTexts[7] = Text8;

        int N = 4;
        context = new Context();
        questions = new List<Question>();
        for (int i = 0; i < N; i++)
        {
            questions.AddRange(context.questions.FindAll(x => x.characteristicId == nums[i]));
        }
        questions = DialogueSay.ButtonTextCreate(context, questions, 0, nums,k, DialogTexts, but_mas);
        k++;
    }


    void Update()
    {
        
    }

    public void button1()
    {

        if (but1.GetComponentInChildren<Text>().text != "...")
        {
            questions = DialogueSay.ButtonTextCreate(context, questions, 1, nums, k, DialogTexts, but_mas);
            k++;
        }
    }

     public void button2()
    {
        if (but2.GetComponentInChildren<Text>().text != "...") { 
        questions = DialogueSay.ButtonTextCreate(context, questions, 2, nums, k, DialogTexts, but_mas);
        k++;
        }
    }

     public void button3()
    {
        if (but3.GetComponentInChildren<Text>().text != "...")
        {
            questions = DialogueSay.ButtonTextCreate(context, questions, 3, nums, k, DialogTexts, but_mas);
            
            k++;
        }
    }

     public void button4()
    {
        if (but4.GetComponentInChildren<Text>().text != "...")
        {
            questions = DialogueSay.ButtonTextCreate(context, questions, 4, nums, k, DialogTexts, but_mas);
            k++;
        }
    }
}
