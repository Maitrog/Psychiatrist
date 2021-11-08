using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class StaticCurrentParamedics
{
    private static List<ParamedicObject> currentParamedic = new List<ParamedicObject>();
    private static ParamedicObject selectedParamedic = new ParamedicObject();

    public static List<ParamedicObject> CurrentParamedic
    {
        get
        {
            return currentParamedic;
        }
        set
        {
            if(value != null)
            {
                currentParamedic = new List<ParamedicObject>(value);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }

    public static ParamedicObject SelectedParamedic
    {
        get
        {
            return selectedParamedic;
        }
        set
        {
            if(value != null)
            {
                selectedParamedic.BecomeCurrent(value);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }

}
