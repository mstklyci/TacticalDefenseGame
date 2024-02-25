using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Varil : MonoBehaviour
{
    public ParticleSystem PatlamaEfekti;
    public float VarilCan;
    public GameObject AnaVaril;

    //Ses
    public AudioSource Patlama_Ses;

    private void Start()
    {
        PatlamaEfekti.Stop();
    }

    public void VarilHasar(float mermi)
    {
        VarilCan -= mermi;
        if (VarilCan <= 0)
        {
            Patlama();
        }
    }
    
    public void Patlama()
    {
        PatlamaEfekti.Play();
        Patlama_Ses.Play();
        StartCoroutine(Bekle(1f));
        Destroy(AnaVaril);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Zombi")
            {
                Zombie zombi = hitCollider.gameObject.GetComponent<Zombie>();

                if (zombi != null)
                {
                    zombi.Zombican(10000);
                }
            }

            if (hitCollider.gameObject.tag == "Polis")
            {
                Police polis = hitCollider.gameObject.GetComponent<Police>();
                Joplu_Police joplu_polis = hitCollider.gameObject.GetComponent<Joplu_Police>();

                if (polis != null)
                {
                    polis.polisCan = -1000f;
                }
                if (joplu_polis != null)
                {
                    joplu_polis.PolisCan = -1000f;
                }
            }
        }
    }
    IEnumerator Bekle(float bekle)
    {
        yield return new WaitForSeconds(bekle);
        Destroy(gameObject);
    }
}