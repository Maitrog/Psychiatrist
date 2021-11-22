using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject navigator;

    public void StartGame()
    {

        navigator.GetComponent<Navigation>().NextScene(4);
    }
}
