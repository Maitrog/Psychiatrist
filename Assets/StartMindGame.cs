using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMindGame : MonoBehaviour
{
    public GameObject panel;
    public GameObject button;
    public GameObject field;
    public GameObject textField;

    public void Begin()
    {
        panel.GetComponentInChildren<Board>().minimaxDepth = int.Parse(textField.GetComponent<Text>().text);
        field.SetActive(false);
        button.SetActive(false);
        panel.SetActive(true);
    }
}
