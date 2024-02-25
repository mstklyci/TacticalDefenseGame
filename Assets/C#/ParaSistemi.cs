using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ParaSistemi : MonoBehaviour
{
    //
    public static int Para;
    public static int EngelLevel = 1;
    public static int SopaliLevel = 1;
    public static int SilahliLevel = 1;

    //
    public Text ParaText;
    public Button EngelYukseltme;
    public Button SopaliYukseltme;
    public Button SilahliYukseltme;
    public Text EngelLevelText;
    public Text SopaliLevelText;
    public Text SilahliLevelText;
    public Text EngeBedeliText;
    public Text SopaliBedeliText;
    public Text SilahliBedeliText;

    void Start()
    {
        LoadSave();
    }

    void OnApplicationQuit()
    {
        Save();
    }

    void Update()
    {
        EngelLevelText.text = ("Level " + EngelLevel).ToString();
        SopaliLevelText.text = ("Level " + SopaliLevel).ToString();
        SilahliLevelText.text = ("Level " + SilahliLevel).ToString();

        ParaText.text = Para.ToString();
        EngeBedeliText.text = ((EngelLevel + 5) * 2).ToString();
        SopaliBedeliText.text = ((SopaliLevel + 5) * 2).ToString();
        SilahliBedeliText.text = ((SilahliLevel + 5) * 3).ToString();  
    }

    public void EngelButon()
    {
        EngelYuks();       
    }
    public void SopaliButon()
    {
        SopaliYuks();       
    }
    public void SilahliButon()
    {
        SilahliYuks();        
    }

    public bool EngelYuks()
    {
        int EYukseltemBedeli = (EngelLevel + 5) * 2;

        if (Para >= EYukseltemBedeli)
        {           
            EngelLevel++;
            Para -= EYukseltemBedeli;
            Save();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool SopaliYuks()
    {
        int SYukseltemBedeli = (SopaliLevel + 5) * 2;

        if (Para >= SYukseltemBedeli)
        {
            SopaliLevel++;
            Para -= SYukseltemBedeli;
            Save();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool SilahliYuks()
    {
        int SiYukseltemBedeli = (SilahliLevel + 5) * 3;

        if (Para >= SiYukseltemBedeli)
        {
            SilahliLevel++;
            Para -= SiYukseltemBedeli;
            Save();
            return true;
        }
        else
        {
            return false;
        }
    }

    //Kayit
    void Save()
    {
        PlayerPrefs.SetInt("ParaSave", Para);
        PlayerPrefs.SetInt("L_Engel", EngelLevel);
        PlayerPrefs.SetInt("L_Sopali", SopaliLevel);
        PlayerPrefs.SetInt("L_Silahli", SilahliLevel);
        PlayerPrefs.Save();

    }
    void LoadSave()
    {
        Para = PlayerPrefs.GetInt("ParaSave", Para);
        EngelLevel = PlayerPrefs.GetInt("L_Engel", EngelLevel);
        SopaliLevel = PlayerPrefs.GetInt("L_Sopali", SopaliLevel);
        SilahliLevel = PlayerPrefs.GetInt("L_Silahli", SilahliLevel);
    }
}