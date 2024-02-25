using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public static float secenek = 0;

    public GameObject Tabancali_Polis;
    public GameObject Joplu_Polis;
    public GameObject Engel;

    //
    public float Spawnsure = 0.1f;
    private float SpawnTimer = 0.0f;

    //SpawnYonu
    public static int spawnYon;

    //Ses
    public AudioSource audioSource;

    //Secim
    public Image EngelSpawn;
    public Image JPolisSpawn;
    public Image SilahliSpawn;
    public Image SniperSpawn;
    public Image SniperSayac;
    public Sprite Yesil;
    public Sprite Mavi;

    //Sniper Sayac
    public static float KalanSure;
    public static float Maxsure = 10f;   

    //EnerjiSistemi
    public Image EnerjiBar;
    public Text EnerjiText;
    public static float Enerji;
    public static float MaxEnerji;
    public float Engel_UretimBedeli , Sopali_Polis_UretimBedeli , Tabancali_Polis_UretimBedeli;

    private void Start()
    {
        Enerji = 100;
        secenek = 0;

        KalanSure = Maxsure;
        Maxsure = 10f;

        Enerji = (ButtonManager.level * 25) + 75;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        SpawnTimer -= Time.deltaTime;

        EnerjiBar.fillAmount = Enerji / MaxEnerji;
        EnerjiText.text = Enerji.ToString();

        if (Enerji >= MaxEnerji)
        {
            Enerji = MaxEnerji;
        }

        if (KalanSure > 0)
        {
            KalanSure -= Time.deltaTime;
            SniperSayac.fillAmount = KalanSure / Maxsure;          
        }

        if (Input.GetMouseButton(0) && SpawnTimer <= 0f)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 spawnPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);

                if (hit.collider.CompareTag("Yol"))
                {
                    if (secenek == 1)
                    {
                        if (Enerji >= Engel_UretimBedeli)
                        {
                            Instantiate(Engel, spawnPosition, Quaternion.Euler(0, spawnYon, 0));
                            SpawnTimer = Spawnsure;
                            audioSource.Play();

                            Enerji -= Engel_UretimBedeli;
                            if (Enerji <= 0)
                            {
                                Enerji = 0;
                            }                          
                        }
                    }
                    else if (secenek == 2)
                    {
                        if (Enerji >= Sopali_Polis_UretimBedeli)
                        {
                            Instantiate(Joplu_Polis, spawnPosition, Quaternion.Euler(0, spawnYon, 0));
                            SpawnTimer = Spawnsure;
                            audioSource.Play();

                            Enerji -= Sopali_Polis_UretimBedeli;
                            if (Enerji <= 0)
                            {
                                Enerji = 0;
                            }
                        }                    
                    }
                    else if (secenek == 3)
                    {
                        if (Enerji >= Tabancali_Polis_UretimBedeli)
                        {
                            Instantiate(Tabancali_Polis, spawnPosition, Quaternion.Euler(0, spawnYon, 0));
                            SpawnTimer = Spawnsure;
                            audioSource.Play();

                            Enerji -= Tabancali_Polis_UretimBedeli;
                            if (Enerji <= 0)
                            {
                                Enerji = 0;
                            }
                        }                        
                    }
                }
            }
        }
    }

    public void EngelSecenek()
    {
        secenek = 1;
        EngelSpawn.sprite = Yesil;
        JPolisSpawn.sprite = Mavi;
        SilahliSpawn.sprite = Mavi;
        SniperSpawn.sprite = Mavi;
    }
    public void JopluPolisSecenek()
    {
        secenek = 2;
        EngelSpawn.sprite = Mavi;
        JPolisSpawn.sprite = Yesil;
        SilahliSpawn.sprite = Mavi;
        SniperSpawn.sprite = Mavi;
    }
    public void TabancaliPolisSpawn()
    {
        secenek = 3;
        EngelSpawn.sprite = Mavi;
        JPolisSpawn.sprite = Mavi;
        SilahliSpawn.sprite = Yesil;
        SniperSpawn.sprite = Mavi;
    }
    public void SniperSecim()
    {
        if (KalanSure / Maxsure <= 0)
        {
            secenek = 4;

            EngelSpawn.sprite = Mavi;
            JPolisSpawn.sprite = Mavi;
            SilahliSpawn.sprite = Mavi;
            SniperSpawn.sprite = Yesil;           
        }
    }
}