using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;
public class NameDb1 : MonoBehaviour
{
    private string _constr = "URI=file:AllDialogues.db";
    private IDbConnection _dbc;
    private IDbCommand _dbcm;
    private IDataReader _dbr;


    public List<Answer> GetAll_answers()
    {
        List<Answer> answers = new List<Answer>();
        _dbc = new SqliteConnection(_constr);
        _dbc.Open();
        _dbcm = _dbc.CreateCommand();
        _dbcm.CommandText = "SELECT * FROM answers";
        _dbr = _dbcm.ExecuteReader();
        object[] buff = new object[3];
        Answer q_buff = new Answer();
        while (_dbr.Read())
        {
            _dbr.GetValues(buff);
            q_buff.questionId = (Int32.Parse(buff[2].ToString()));
            q_buff.id = (Int32.Parse(buff[0].ToString()));
            q_buff.answer = buff[1].ToString();
            answers.Add(new Answer(q_buff));
        }
        return answers;


    }

    public List<Characteristic> GetAll_Characteristics()
    {
        List<Characteristic> characteristics = new List<Characteristic>();
        _dbc = new SqliteConnection(_constr);
        _dbc.Open();
        _dbcm = _dbc.CreateCommand();
        _dbcm.CommandText = "SELECT * FROM characteristics";
        _dbr = _dbcm.ExecuteReader();
        object[] buff = new object[3];
        Characteristic q_buff = new Characteristic();
        while (_dbr.Read())
        {
            _dbr.GetValues(buff);
            q_buff.Characters=(Characters)(Int32.Parse(buff[1].ToString()));
            q_buff.id = (Int32.Parse(buff[0].ToString()));
            characteristics.Add(new Characteristic(q_buff));
        }
        return characteristics;


    }


    public List<Question> GetAll_questions()
    {
        List<Question> questions = new List<Question>();
        _dbc = new SqliteConnection(_constr);
        _dbc.Open();
        _dbcm = _dbc.CreateCommand();
        _dbcm.CommandText = "SELECT * FROM questions";
        _dbr = _dbcm.ExecuteReader();
        object[] buff=new object[4];
        Question q_buff = new Question();
        while (_dbr.Read())
        {
            _dbr.GetValues(buff);
            q_buff.characteristicId = (Int32.Parse(buff[2].ToString()));
            q_buff.id= (Int32.Parse(buff[0].ToString()));
            q_buff.question = buff[1].ToString();
            q_buff.text_short = buff[3].ToString();
            questions.Add(new Question(q_buff));
            
        }
        
        return questions;


    }

   
}