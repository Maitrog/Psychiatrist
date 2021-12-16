using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


class DialogueSay
{
    public static List<Question> ButtonTextCreate(Context context, List<Question> questions, int buttonNum, int[] charact, int charactNum, Text[] newText, Button[] buttonMas)
    {

        if (charactNum > 5) return questions;
        List<Question> questions_non_repeat = new List<Question>();
        int k = 1;
        List<Question> quest_char = new List<Question>();
        Question buff = new Question();
        if (buttonNum != 0)
        {
            buff = context.questions.Find(x => (x.text_short == (buttonMas[buttonNum - 1].GetComponentInChildren<Text>().text.Substring(3)) && x.characteristicId == charact[charactNum - 1]));
            
            newText[charactNum * 2 - 2].text = buff.question;
            newText[charactNum * 2 + 1 - 2].text = context.answers.Find(x => x.questionId == buff.id).answer;
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
        Debug.Log(questions.Count + "fghj");
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




    public static List<Question> ButtonTextCreate(Context context, List<Question> questions, int buttonNum, int[] charact, int charactNum, string[] newText, Text[] TextBoxes, Button[] buttonMas)

    {
        //Debug.Log("DIVIDE");
        if (charactNum > 6) return questions;
        List<Question> questions_non_repeat = new List<Question>();
        int k = 1;
        List<Question> quest_char = new List<Question>();
        Question buff = new Question();

        if (charactNum % 2 == 0)
        {
            Dialoges.CurrenrPages = (Dialoges.CurrenrPages + 1) % Dialoges.NumQuadros;
        }

        if (buttonNum != 0)
        {

            buff = context.questions.Find(x => (x.text_short == (buttonMas[buttonNum - 1].GetComponentInChildren<Text>().text.Substring(3)) && x.characteristicId == charact[charactNum - 1]));
      
            newText[charactNum * 2 - 2] = buff.question;
            newText[charactNum * 2 + 1 - 2] = context.answers.Find(x => x.questionId == buff.id).answer;
            if (charactNum % 2 == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    TextBoxes[i].text = "";
                }

            }
            if (charactNum % 2 != 0)
            {
                TextBoxes[(charactNum % 2) * 2 - 2].text = buff.question;
                TextBoxes[(charactNum % 2) * 2 + 1 - 2].text = context.answers.Find(x => x.questionId == buff.id).answer;
            }
            else
            {
                TextBoxes[(charactNum % 2) * 2 + 2].text = buff.question;
                TextBoxes[(charactNum % 2) * 2 + 1 + 2].text = context.answers.Find(x => x.questionId == buff.id).answer;
            }


            

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
        if (charactNum != 6)
        {
            Debug.Log(questions.Count + "questions.Count");
            foreach (Question i in questions)
            {
               
                if (k < 5 && i.characteristicId == charact[charactNum] && quest_char.Find(x => i.question == x.question) == null)
                {
                    //Debug.Log("asdfghjkl");
                    quest_char.Add(i);
                    buttonMas[k - 1].GetComponentInChildren<Text>().text = (k.ToString() + ". " + i.text_short);
                    k++;
                }

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
            Debug.Log("qnr" + questions_non_repeat.Count);
            return questions_non_repeat;

        }
        else
        {
            return questions;
        }
    }

}

public class Question
{
    public int id { get; set; }//1
    public string question { get; set; }//why
    public Answer answer { get; set; }
    public string text_short { get; set; }
    public int characteristicId { get; set; }//2

    public Question(Question q)
    {
        this.question = q.question;
        this.id = q.id;
        this.characteristicId = q.characteristicId;
        this.text_short = q.text_short;
    }

    public Question()
    {

    }

   
}
public class Answer
{
    public int id { get; set; }//14
    public string answer { get; set; }//all good
    public int questionId { get; set; }//1

    public Answer(Answer a)
    {
        this.questionId = a.questionId;
        this.id = a.id;
        this.answer = a.answer;
    }

    public Answer()
    {

    }

    public Answer(int questionid, int id, string answer)
    {
        this.questionId = questionid;
        this.id = id;
        this.answer = answer;

    }

}
public class Characteristic
{
    public int id { get; set; }//2
    public Deviation Characters { get; set; }//zloy
    public List<Question> questions { get; set; }

    public Characteristic(Characteristic c)
    {
        this.Characters = c.Characters;
        this.id = c.id;
        this.questions = new List<Question>();
    }

    public Characteristic()
    {
        this.questions = new List<Question>();
    }
}

class Context
{
    public List<Characteristic> characteristics { get; set; }
    public List<Answer> answers { get; set; }
    public List<Question> questions { get; set; }
    public Context()
    {
        int i;
        NameDb1 buff = new NameDb1();
        characteristics = buff.GetAll_Characteristics();
        answers = buff.GetAll_answers();
        questions = buff.GetAll_questions();
        for (i = 0; i < questions.Count; i++)
        {
            questions[i].answer = answers.Find(x => x.questionId == questions[i].id);
        }
        for (i = 0; i < characteristics.Count; i++)
        {
            characteristics[i].questions = new List<Question>();
            //;
            characteristics[i].questions.AddRange(questions.FindAll(x => x.characteristicId == characteristics[i].id));
        }
    }
}
