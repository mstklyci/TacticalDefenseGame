using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hikaye : MonoBehaviour
{
    public int secim;

    public GameObject Hikaye_1;
    public GameObject Hikaye_2;
    public GameObject Hikaye_3;
    public GameObject Hikaye_4;
    public GameObject Hikaye_5;
    public GameObject Hikaye_6;
    public GameObject Hikaye_7;
    public GameObject Hikaye_8;

    public void Start()
    {
        secim = 0;

        Hikaye_1.SetActive(false);
        Hikaye_2.SetActive(false);
        Hikaye_3.SetActive(false);
        Hikaye_4.SetActive(false);
        Hikaye_5.SetActive(false);
        Hikaye_6.SetActive(false);
        Hikaye_7.SetActive(false);
        Hikaye_8.SetActive(false);
    }

    public void Secim()
    {
        secim += 1;
    }

    public void Update()
    {
        if (secim <= 0)
        {
            Hikaye_1.SetActive(true);      
        }
        else if (secim == 1)
        {
            Hikaye_1.SetActive(false);
            Hikaye_2.SetActive(true);
        }
        else if (secim == 2)
        {
            Hikaye_2.SetActive(false);
            Hikaye_3.SetActive(true);
        }
        else if (secim == 3)
        {
            Hikaye_3.SetActive(false);
            Hikaye_4.SetActive(true);
        }
        else if (secim == 4)
        {
            Hikaye_4.SetActive(false);
            Hikaye_5.SetActive(true);
        }
        else if (secim == 5)
        {
            Hikaye_5.SetActive(false);
            Hikaye_6.SetActive(true);
        }
        else if (secim == 6)
        {
            Hikaye_6.SetActive(false);
            Hikaye_7.SetActive(true);
        }
        else if (secim == 7)
        {
            Hikaye_7.SetActive(false);
            Hikaye_8.SetActive(true);
        }
        else if (secim >= 8)
        {
            SceneManager.LoadScene(0);
        }
    }
}