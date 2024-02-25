using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    
    //
    private Transform Target;
    NavMeshAgent agent;
    Animator anim;

    //Tag
    public string targetTag = "";

    //Degerler
    public float mesafe;
    public float zombiCan;
    public float zombiHiz;
    float timer = 1.0f;
    float elapsedTime = 0.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Target= GameObject.FindGameObjectWithTag("Polis").transform;
    }

    void Update()
    {
        agent.destination = Target.position;

        Mesafe();

        Vector3 targetPosition = new Vector3(0f, 0f, 0.1f);
        transform.Translate(targetPosition * zombiHiz * Time.deltaTime);

        if (zombiCan <= 0)
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
            if (enYakinMesafe > 1 && enYakinMesafe <= 3)
            {
                transform.LookAt(enYakinHedef.transform.position);
                anim.SetBool("Saldir", false);
                zombiHiz = 25f;

                if (zombiCan <= 0)
                {
                    Olme();
                }
            }
            else if (enYakinMesafe <= 1)
            {
                anim.SetBool("Saldir", true);
                zombiHiz = 0f;

                if (zombiCan <= 0)
                {
                    Olme();
                }

                elapsedTime += Time.deltaTime;
                if (elapsedTime >= timer)
                {
                    if (enYakinHedef.GetComponent<Police>() != null)
                    {
                        enYakinHedef.GetComponent<Police>().polisCan -= 5f;
                    }
                    if (enYakinHedef.GetComponent<Joplu_Police>() != null)
                    {
                        enYakinHedef.GetComponent<Joplu_Police>().PolisCan -= 5f;
                    }
                    if (enYakinHedef.GetComponent<Engel>() != null)
                    {
                        enYakinHedef.GetComponent<Engel>().engelCan -= 5f;
                    }

                    elapsedTime = 0.0f;
                }
            }
            else
            {
                anim.SetBool("Saldir", false);
                zombiHiz = 25f;
            }
        }
    }

    public void Zombican(float mermi)
    {
        zombiCan -= mermi;
    }

    void Olme()
    {       
        Spawner.Enerji += 2;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kaybet"))
        {
            SceneManager.LoadScene(1);
            LevelSonu.kazanma = false;
        }
    }
    private void Awake()
    {
        zombiCan = 10 + (2* ButtonManager.level);
    }
}