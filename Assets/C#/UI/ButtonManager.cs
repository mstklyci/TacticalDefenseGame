using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{

    public GameObject OyunIci;
    public GameObject OyunOnu;

    public GameObject AyarlarMenu;
    public GameObject SesKapali;

    public string KazanmaKontrol = "Zombi";

    //LevelYazi
    public Text LeveYazi;
    public Text LevelOyun;

    //LevelSistemi 
    public static int level = 1;
    public GameObject kamera;

    void Start()
    {
        Time.timeScale = 0f;
        OyunIci.SetActive(false);
        OyunOnu.SetActive(true);
        AyarlarMenu.SetActive(false);
        LeveYazi.text = ("Level " + level).ToString();
        LevelOyun.text = ("Level " + level).ToString();
        level = PlayerPrefs.GetInt("levelSave", 1);
        LoadLevel();
    }

    public void PlayButton()
    {
        LoadLevel();
        Time.timeScale = 1f;
        OyunIci.SetActive(true);        
        OyunOnu.SetActive(false);
        LevelOyun.text = ("Level " + level).ToString();
    }
    public void RestartButton() 
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 0f;
    }

    public void HikayeButton()   
    {
        SceneManager.LoadScene(2);
    }
    public void MarketButton()
    {
        SceneManager.LoadScene(3);
    }
    
    bool menuAcik = false;
    public void Settings()
    {       
        menuAcik = !menuAcik;

        if (menuAcik)
        {
            AyarlarMenu.SetActive(true);
        }
        else
        {
            AyarlarMenu.SetActive(false);
        }
    }

    bool seslerAcik = true;
    public void SesButton()
    {
        seslerAcik = !seslerAcik;
        if (seslerAcik)
        {
            AudioListener.volume = 1.0f;
            SesKapali.SetActive(false);
        }
        else
        {
            SesKapali.SetActive(true);
            AudioListener.volume = 0.0f;
        }
    }

    void Update()
    {
        GameObject taggedObject = GameObject.FindWithTag(KazanmaKontrol);

        if (taggedObject == null)
        {
            SceneManager.LoadScene(1);
            LevelSonu.kazanma = true;
            level += 1;

            PlayerPrefs.SetInt("levelSave", level);
            PlayerPrefs.Save();
        }
        if (level > 10)
        {
            level = 1;
            PlayerPrefs.SetInt("levelSave", level);
            PlayerPrefs.Save();
        }
        LevelSistemi();
    }
    
    void LoadLevel()
    {
       level = PlayerPrefs.GetInt("levelSave", level);
       LeveYazi.text = ("Level " + level).ToString();
    }

    void LevelSistemi()
    {
        Spawner.MaxEnerji = (level * 25) + 75;
        if (level == 1)
        {
            LevelOyun.text = ("Level " + level).ToString();
            kamera.transform.position = new Vector3(-20, 15, 0);
            kamera.transform.eulerAngles = new Vector3(40, 90, 0);
            Spawner.spawnYon = 90;
        }
        else if (level == 2)
        {
            kamera.transform.position = new Vector3(32, 15, -4);
            kamera.transform.eulerAngles = new Vector3(40, 0, 0);
            Spawner.spawnYon = 0;
        }
        else if (level == 3)
        {
            kamera.transform.position = new Vector3(28, 15, 32);
            kamera.transform.eulerAngles = new Vector3(40, 90, 0);
            Spawner.spawnYon = 90;
        }
        else if (level == 4)
        {
            kamera.transform.position = new Vector3(108, 15, 32);
            kamera.transform.eulerAngles = new Vector3(40, 90, 0);
            Spawner.spawnYon = 90;
        }
        else if (level == 5)
        {
            kamera.transform.position = new Vector3(192, 15, 36);
            kamera.transform.eulerAngles = new Vector3(40, 180, 0);
            Spawner.spawnYon = 180;
        }
        else if (level == 6)
        {
            kamera.transform.position = new Vector3(192, 15, -51);
            kamera.transform.eulerAngles = new Vector3(40, 180, 0);
            Spawner.spawnYon = 180;
        }
        else if (level == 7)
        {
            kamera.transform.position = new Vector3(188, 15, -112);
            kamera.transform.eulerAngles = new Vector3(40, 90, 0);
            Spawner.spawnYon = 90;
        }
        else if (level == 8)
        {
            kamera.transform.position = new Vector3(260, 15, -112);
            kamera.transform.eulerAngles = new Vector3(40, 90, 0);
            Spawner.spawnYon = 90;
        }
        else if (level == 9)
        {
            kamera.transform.position = new Vector3(324, 15, -112);
            kamera.transform.eulerAngles = new Vector3(40, 90, 0);
            Spawner.spawnYon = 90;
        }
        else if (level == 10)
        {
            kamera.transform.position = new Vector3(388, 15, -112);
            kamera.transform.eulerAngles = new Vector3(40, 90, 0);
            Spawner.spawnYon = 90;
        }
    }
}