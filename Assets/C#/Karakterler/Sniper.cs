    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    //Animator
    Animator anim;

    //Ates
    public Transform namluucu, mermi;
    Transform klon;
    private float Zamanlayici = 0f;
    private bool Atesizni = false;

    //Ses
    public AudioSource Ates_Ses;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Spawner.secenek == 4 && Zamanlayici <= 0)
        {
            Zamanlayici = 1f;
        }

        if (Zamanlayici > 0)
        {
            Zamanlayici -= Time.deltaTime;
            if (Zamanlayici <= 0)
            {
                Atesizni = true;
            }
        }

        if (Atesizni)
        {
            Ates();
        }
    }

    void Ates()
    {
        if (Spawner.secenek == 4)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 targetDirection = hit.point - transform.position;
                    targetDirection.y = 0;
                    Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 15);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                klon = Instantiate(mermi, namluucu.position, namluucu.rotation);
                klon.GetComponent<Rigidbody>().AddForce(klon.transform.forward * 400f);
                Ates_Ses.Play();

                anim.SetBool("Ates", true);

                Zamanlayici = 0f;
                Atesizni = false;
                Spawner.secenek = 0;
                Spawner.KalanSure = Spawner.Maxsure;
            }
        }
        else
        {
            anim.SetBool("Ates", false);
        }
    }
}