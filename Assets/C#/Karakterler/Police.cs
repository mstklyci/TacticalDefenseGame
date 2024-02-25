using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Police : MonoBehaviour
{
    //Animator
    Animator anim;

    //DusmanaBakma
    public string targetTag = "";

    //Degerler
    public float mesafe;
    private float timer;
    public float polisCan;

    //Ates
    public Transform namluucu, mermi;
    Transform klon;

    //Ses
    public AudioSource Ates_Ses;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       Ates();     
       timer += Time.deltaTime;
      
       if (polisCan <= 0)
       {
            Olme();
       }
    }

    void Ates()
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
            if (enYakinMesafe <= 15)
            {
                transform.LookAt(enYakinHedef.transform.position);
                anim.SetBool("Ates", true);                

                if (timer >= 2f)
                {
                    klon = Instantiate(mermi, namluucu.position, gameObject.transform.rotation);
                    klon.GetComponent<Rigidbody>().AddForce(klon.transform.forward * 100f);
                    Ates_Ses.Play();

                    timer = 0f;
                }
            }
            else
            {
                anim.SetBool("Ates", false);
            }
        }
        else
        {
            anim.SetBool("Ates", false);
        }

        if (polisCan <= 0)
        {
            Olme();
        }
    }

    public void Poliscan(float mermi)
    {
        polisCan -= mermi;
    }

    void Olme()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        polisCan = 5 + ParaSistemi.SilahliLevel;
    }
}