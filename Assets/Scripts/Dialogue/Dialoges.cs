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
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image[] ImageMas = new Image[4];
    public static int NumQuadros = 3;
    public static Text[] texts;
    public static int CurrenrPages = 0;
    public int[] quadroNumPages = new int[NumQuadros];
    private static string[] buff;

    public int CharactNum;

    public static string[] Replices = new string[12];


    
    
    void ImageMasCreate()
    {
        ImageMas[0] = image1;
        ImageMas[1] = image2;
        ImageMas[2] = image3;
        ImageMas[3] = image4;
    }

    public static void TextBoxSet(Image[] ImageMas)
    {
        //clearTextBoxes();
        for (int i = 0; i < 4; i++)
        {
            if (texts[i].text != "")
            {
                ImageMas[i].enabled = true;
            }
            else
            {
                ImageMas[i].enabled = false;
            }
        }

        
    }


    private void TextsMassiveCreate()
    {
        texts = new Text[4];
        texts[0] = Text1;
        texts[1] = Text2;
        texts[2] = Text3;
        texts[3] = Text4;
    }

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

        //UpdateSave();


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
        ImageMasCreate();
        CurrenrPages = (CurrenrPages+1) % NumQuadros;
        TextsMassiveCreate();
        for (int i = 0; i < 4; i++)
        {
            texts[i].text = Replices[i + CurrenrPages * 4];

        }
        TextBoxSet(ImageMas);
    }


    public static void ChangePageToCurrent(Image[] ImageMas)
    {

      
        CurrenrPages = (ButtonTextManager.k-2) / 2;
        Debug.Log("bb"+CurrenrPages);
        for (int i = 0; i < 4; i++)
        {
            texts[i].text = Replices[i + CurrenrPages * 4];

        }

        TextBoxSet(ImageMas);

    }



    public static void save()
    {
        Replices.CopyTo(buff, 0);
        StaticClassSave.texts = buff;
       StaticClassSave.CurrenrPage = CurrenrPages ;
        StaticClassSave.saveFlag = true;
         StaticClassSave.charactNum=ButtonTextManager.k;
        StaticClassSave.questions = ButtonTextManager.questions;

    }
    public static void UpdateSave()
    {
        if (texts.Length!=0)
        {
            save();
        }
        
    }
}
