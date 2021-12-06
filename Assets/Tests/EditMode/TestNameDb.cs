using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestNameDb
{
    // A Test behaves as an ordinary method
    [Test]
    public void WhenGetingMaleName_ThenResultIsNotEmpty()
    {
        NameDb db = new NameDb();
        List<string> maleName = db.GetAllMaleName();
        Assert.Greater(maleName.Count, 0);
    }
    [Test]
    public void WhenGetingFemaleName_ThenResultIsNotEmpty()
    {
        NameDb db = new NameDb();
        List<string> femaleName = db.GetAllFemaleName();
        Assert.Greater(femaleName.Count, 0);
    }
    [Test]
    public void WhenGetingMaleSurname_ThenResultIsNotEmpty()
    {
        NameDb db = new NameDb();
        List<string> maleSurname = db.GetAllMaleSurname();
        Assert.Greater(maleSurname.Count, 0);
    }
    [Test]
    public void WhenGetingFrmaleSurname_ThenResultIsNotEmpty()
    {
        NameDb db = new NameDb();
        List<string> femaleSurname = db.GetAllFemaleSurname();
        Assert.Greater(femaleSurname.Count, 0);
    }

    [Test]
    public void WhenGetingMalePatronymic_ThenResultIsNotEmpty()
    {
        NameDb db = new NameDb();
        List<string> malePatronymic = db.GetAllMalePatronymic();
        Assert.Greater(malePatronymic.Count, 0);
    }
    [Test]
    public void WhenGetingFrmalePatronymic_ThenResultIsNotEmpty()
    {
        NameDb db = new NameDb();
        List<string> femalePatronymic = db.GetAllFemalePatronymic();
        Assert.Greater(femalePatronymic.Count, 0);
    }
}
