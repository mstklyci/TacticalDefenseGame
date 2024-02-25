using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Joplu_Police : MonoBehaviour
{
    //Animator
    Animator anim;

    //Tag
    public string targetTag = "";

    //Degerler
    public float mesafe;
    public float PolisCan;
    public float PolisHiz;
    private float PolisHasar;

    //
    float timer = 1.0f;
    float elapsedTime = 0.0f;

    //Ses
    public AudioSource Ates_Ses;
    private float ses_timer = 0f;
    void Start()
    {     
        anim = GetComponent<Animator>();
        PolisHiz = 0f;
    }

    void Update()
    {
        Mesafe();
        ses_timer += Time.deltaTime;

        Vector3 targetPosition = new Vector3(0f, 0f, 0.1f);
        transform.Translate(targetPosition * PolisHiz * Time.deltaTime);

        if (PolisCan <= 0)
        {
            Olme();
        }
    }

    void Mesafe()
    {
        GameObject[] hedefNesneler = GameObject.FindGameObjectsWithTag(targetTag);
        float enYakinMesafe = float.MaxValue;
        GameObject enYakinHedef = null;

        foreach (GameObject hedefNesne in hedefNesneler)
        {
            float mesafe = Vector3.Distance(gameObject.transform.position, hedefNesne.transform.position);

            if (mesafe < enYakinMesafe)
            {
                enYakinMesafe = mesafe;
                enYakinHedef = hedefNesne;
            }
        }

        if (enYakinHedef != null)
        {
            if (enYakinMesafe > 5)
            {
                anim.SetBool("Yuru", false);
                anim.SetBool("Saldir", false);
                PolisHiz = 0f;
            }
            if (enYakinMesafe > 1 && enYakinMesafe <= 5)
            {
                transform.LookAt(enYakinHedef.transform.position);
                anim.SetBool("Yuru", true);
                PolisHiz = 15f;

                if (PolisCan <= 0)
                {
                    Olme();
                }
            }
            else if (enYakinMesafe <= 1)
            {
                anim.SetBool("Saldir", true);               
                PolisHiz = 0f;
                if (ses_timer >= 1.2f)
                {
                    Ates_Ses.Play();
                    ses_timer = 0f;
                }

                if (PolisCan <= 0)
                {
                    Olme();
                }

                elapsedTime += Time.deltaTime;
                if (elapsedTime >= timer)
                {
                    if (enYakinHedef.GetComponent<Zombie>() != null)
                    {
                        enYakinHedef.GetComponent<Zombie>().zombiCan -= PolisHasar;
                    }
  
                    elapsedTime = 0.0f;
                }
            }
        }
        else if (enYakinHedef == null)
        {
            anim.SetBool("Yuru", false);
            anim.SetBool("Saldir", false);
            PolisHiz = 0f;
        }
    }

    public void Zombican(float yumruk)
    {
        PolisCan -= yumruk;
    }

    void Olme()
    {
        Destroy(gameObject);
    }
    private void Awake()
    {
        PolisHasar = 5 + ParaSistemi.SopaliLevel;
        PolisCan = 10 + ParaSistemi.SopaliLevel;
    }
}