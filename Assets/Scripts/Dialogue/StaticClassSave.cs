using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StaticClassSave 
{
    public static string[] texts=new string[4];
    public static string[] ButTexts = new string[4];
    public static int CurrenrPage;
    public static bool saveFlag=false;
    public static bool endFlag=false;
    public static int charactNum = 0;
    public static List<Question> questions;




    public static string[] Texts
    {
        get
        {
            return texts;
        }
        set
        {
            texts = value;
        }
    }

    public static bool SaveFlag
    {
        get
        {
            return saveFlag;
        }
        set
        {
            saveFlag = value;
        }
    }

    public static bool EndFlag
    {
        get
        {
            return endFlag;
        }
        set
        {
            endFlag = value;
        }
    }


    /*public static int CharactNum
    {
        get
        {
            return endFlag;
        }
        set
        {
            endFlag = value;
        }
    }*/

}
