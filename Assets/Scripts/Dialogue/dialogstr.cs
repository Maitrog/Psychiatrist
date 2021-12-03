/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogstr : MonoBehaviour
{
    public static List<Question> ButtonTextCreate(Context context, List<Question> questions, int buttonNum, int[] charact, int charactNum, string[] newText, Button[] buttonMas)
    {

        if (charactNum > 5) return questions;
        List<Question> questions_non_repeat = new List<Question>();
        int k = 1;
        List<Question> quest_char = new List<Question>();
        Question buff = new Question();
        if (buttonNum != 0)
        {
            buff = context.questions.Find(x => (x.text_short == (buttonMas[buttonNum - 1].GetComponentInChildren<Text>().text.Substring(3)) && x.characteristicId == charact[charactNum - 1]));
            newText[charactNum * 2 - 2] = buff.question;
            newText[charactNum * 2 + 1 - 2] = context.answers.Find(x => x.questionId == buff.id).answer;
        }
        while (questions.Find(x => ((buff.characteristicId == x.characteristicId) || (buff.question == x.question))) != null)
        {
            questions.Remove(questions.Find(x => ((buff.characteristicId == x.characteristicId) || (buff.question == x.question))));
        }
        for (int l = 0; l < questions.Count; l++)
        {

            if (((buff.characteristicId == questions[l].characteristicId) || (buff.question == questions[l].question)))
            {
                questions.Remove(buff);
            }
        }
        k = 1;
        foreach (Question i in questions)
        {
            if (k < 5 && i.characteristicId == charact[charactNum] && quest_char.Find(x => i.question == x.question) == null)
            {
                quest_char.Add(i);
                buttonMas[k - 1].GetComponentInChildren<Text>().text = (k.ToString() + ". " + i.text_short);
                k++;
            }

        }
        while (k < 5)
        {
            buttonMas[k - 1].GetComponentInChildren<Text>().text = "...";
            k++;
        }
        if (buttonNum != 0)
        {
            if (quest_char.Count != 0)
            {
                questions_non_repeat = new List<Question>();
                foreach (Question i in questions)
                {
                    if (!((buff.characteristicId == i.characteristicId) || (buff.question == i.question)))
                    {
                        questions_non_repeat.Add(i);
                    }
                }
            }
            return questions_non_repeat;
        }
        else
        {
            return questions;
        }
    }
}*/
