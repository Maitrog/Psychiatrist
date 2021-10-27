using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
public class NameDb : MonoBehaviour
{
    private string _constr = "URI=file:AllName.db";
    private IDbConnection _dbc;
    private IDbCommand _dbcm;
    private IDataReader _dbr;

    public List<string> GetAllMaleName()
    {
        List<string> names = new List<string>();
        _dbc = new SqliteConnection(_constr);
        _dbc.Open();
        _dbcm = _dbc.CreateCommand();
        _dbcm.CommandText = "SELECT Name FROM MALE_NAME";
        _dbr = _dbcm.ExecuteReader();

        while (_dbr.Read())
        {
            names.Add(_dbr.GetString(0));
        }

        return names;
    }

    public List<string> GetAllFemaleName()
    {
        List<string> names = new List<string>();
        _dbc = new SqliteConnection(_constr);
        _dbc.Open();
        _dbcm = _dbc.CreateCommand();
        _dbcm.CommandText = "SELECT Name FROM FEMALE_NAME";
        _dbr = _dbcm.ExecuteReader();

        while (_dbr.Read())
        {
            names.Add(_dbr.GetString(0));
        }

        return names;
    }

    public List<string> GetAllMaleSurname()
    {
        List<string> surnames = new List<string>();
        _dbc = new SqliteConnection(_constr);
        _dbc.Open();
        _dbcm = _dbc.CreateCommand();
        _dbcm.CommandText = "SELECT Surname FROM MALE_SURNAME";
        _dbr = _dbcm.ExecuteReader();

        while (_dbr.Read())
        {
            surnames.Add(_dbr.GetString(0));
        }

        return surnames;
    }

    public List<string> GetAllFemaleSurname()
    {
        List<string> surnames = new List<string>();
        _dbc = new SqliteConnection(_constr);
        _dbc.Open();
        _dbcm = _dbc.CreateCommand();
        _dbcm.CommandText = "SELECT Surname FROM FEMALE_SURNAME";
        _dbr = _dbcm.ExecuteReader();

        while (_dbr.Read())
        {
            surnames.Add(_dbr.GetString(0));
        }

        return surnames;
    }

    public List<string> GetAllMalePatronymic()
    {
        List<string> patronymics = new List<string>();
        _dbc = new SqliteConnection(_constr);
        _dbc.Open();
        _dbcm = _dbc.CreateCommand();
        _dbcm.CommandText = "SELECT Patronymic FROM MALE_PATRONYMIC";
        _dbr = _dbcm.ExecuteReader();

        while (_dbr.Read())
        {
            patronymics.Add(_dbr.GetString(0));
        }

        return patronymics;
    }

    public List<string> GetAllFemalePatronymic()
    {
        List<string> patronymics = new List<string>();
        _dbc = new SqliteConnection(_constr);
        _dbc.Open();
        _dbcm = _dbc.CreateCommand();
        _dbcm.CommandText = "SELECT Patronymic FROM FEMALE_PATRONYMIC";
        _dbr = _dbcm.ExecuteReader();

        while (_dbr.Read())
        {
            patronymics.Add(_dbr.GetString(0));
        }

        return patronymics;
    }
}
