using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//сохранение по нажатии кнопки на диалоге

public class Dialoges : MonoBehaviour
{
    private static int N = 12;//число нужных текстовых окон(8 окон=4 вопроса и 4 ответа)
    //public GameObject examle;
    public Button but1;
    public Text Text1;
    public Text Text2;
    public Text Text3;
    public Text Text4;
    //public static Text Text5;
    //public static Text Text6;
    //public static Text Text7;
    //public static Text Text8;
    public static int NumQuadros = 3;
    public static Text[] texts;
    public static int CurrenrPages = 0;
    public int[] quadroNumPages = new int[NumQuadros];
    private string[] buff;

    public int CharactNum;

    public static string[] Replices = new string[12];

    /*public void fillVector(Vector2[] vectors)
    {

    

    }*/

    private void TextsMassiveCreate()
    {
        texts = new Text[4];
        texts[0] = Text1;
        texts[1] = Text2;
        texts[2] = Text3;
        texts[3] = Text4;
        /* texts[4] = Text5;
         texts[5] = Text6;
         texts[6] = Text7; 
         texts[7] = Text8;*/
        //texts[0] = Text1;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(StaticClassSave.texts.Length);
        buff=new string[N ];
        texts = new Text[N ];
        //StaticClassSave.texts.CopyTo(texts, 0);
        //CurrenrPages = StaticClassSave.CurrenrPage;
        this.TextsMassiveCreate();



        //texts[];
        if (StaticClassSave.saveFlag)
        //if (true)
        {
            StaticClassSave.texts.CopyTo(Replices, 0);
            CurrenrPages = StaticClassSave.CurrenrPage;
            CharactNum = StaticClassSave.charactNum;

            for (int i = 0; i < 4; i++)
            {
                texts[i].text = Replices[i + CurrenrPages * 4];
                

            }
            
            //Text1.text = "fgdhdrdhrdrhdrh";
            //newText[charactNum * 2 + 1 - 2] = context.answers.Find(x => x.questionId == buff.id).answer;

        }
        



        //
        //texts.CopyTo(StaticClassSave.texts,0);
        // texts = StaticClassSave.texts;

        //CurrenrPages.Copy();
        //Vector2[] buff = new Vector2[4];

        //examle.transform.position= new Vector2(-5, 0);
        //transform.position = new Vector3(transform.position.x, 54);
        //examle.transform.Translate(new Vector2(-5, 0));
        //examle.transform.Translate(examle.transform.position + (new Vector2(-385, 0)));

    }

    public void ChangePage()
    {
        CurrenrPages = (CurrenrPages+1) % NumQuadros;
        TextsMassiveCreate();
        for (int i = 0; i < 4; i++)
        {
            texts[i].text = Replices[i + CurrenrPages * 4];

        }
        


        //Vector2[] buff = new Vector2[4];
        //Vector2[] page1 = new Vector2[4];
        //Vector2[] page2 = new Vector2[4];

    }


    public static void ChangePageToCurrent()
    {
        //CurrenrPages = (CurrenrPages + 1) % NumQuadros;
        //TextsMassiveCreate();
        CurrenrPages = (ButtonTextManager.k-2) / 2;
        Debug.Log("bb"+CurrenrPages);
        for (int i = 0; i < 4; i++)
        {
            texts[i].text = Replices[i + CurrenrPages * 4];

        }



        //Vector2[] buff = new Vector2[4];
        //Vector2[] page1 = new Vector2[4];
        //Vector2[] page2 = new Vector2[4];

    }



    public void save()
    {

        //Text[] buff;
        Replices.CopyTo(buff, 0);
        //texts.CopyTo(StaticClassSave.texts, 0);
        //StaticClassSave.texts = buff;
        StaticClassSave.texts = buff;
       StaticClassSave.CurrenrPage = CurrenrPages ;
        StaticClassSave.saveFlag = true;
         StaticClassSave.charactNum=ButtonTextManager.k;
        StaticClassSave.questions = ButtonTextManager.questions;

    }

    // Update is called once per frame
    void Update()
    {
        if (texts.Length!=0)
        {
            save();
        }
        
    }
}
