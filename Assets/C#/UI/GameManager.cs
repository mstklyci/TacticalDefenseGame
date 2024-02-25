using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool hasRemoveAds;
    [SerializeField] private TMP_Text Para;
    [SerializeField] private TMP_Text AdsRemoved;


    private void Start()
    {
        ParaSistemi.Para = PlayerPrefs.GetInt("ParaSave", ParaSistemi.Para);
        int boolValue = PlayerPrefs.GetInt("boolValue");

        if (boolValue == 1)
        {
            hasRemoveAds = true;
            AdsRemoved.text = "AdsRemoved";
        }
        else
        {
            hasRemoveAds = false;
            AdsRemoved.text = "AdsNotRemoved";
        }
        Para.text = ":" + Para.ToString();
        AdsRemoved.text = "AdsRemoved";
    }

    public void GetReward(int coinsAmount, bool isAds)
    {
        if (!isAds)
        {
            ParaSistemi.Para += coinsAmount;
            PlayerPrefs.SetInt("ParaSave", ParaSistemi.Para);
            Para.text = ":" + Para.ToString();
            PlayerPrefs.Save();
        }
        else 
        {
            PlayerPrefs.SetInt("boolValue", 1);

            int boolValue = 1;

            if (boolValue == 1)
            {
                hasRemoveAds = true;
                AdsRemoved.text = "AdsRemoved";
            }
            else
            {
                hasRemoveAds = false;
                AdsRemoved.text = "AdsNotRemoved";
            }
        }
    }
}