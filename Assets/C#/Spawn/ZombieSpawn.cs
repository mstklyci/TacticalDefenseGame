using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject Zombi_10;
    public GameObject Zombi_5;
    private float SpawnSure5sn = 5f;

    private float timer;
    private float spawnBitis;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        spawnBitis += Time.deltaTime;

        if (timer >= SpawnSure5sn)
        {
            Leveller();
            timer = 0f;
        }
        if (spawnBitis >= 16f)
        {
            gameObject.SetActive(false);
        }
    }

    void Leveller()
    {
        if (ButtonManager.level == 1)
        {
            Instantiate(Zombi_5, new Vector3(32, 0, 18), gameObject.transform.rotation);
        }
        else if (ButtonManager.level == 2)
        {
            Instantiate(Zombi_5, new Vector3(30, 0, 61), gameObject.transform.rotation);
            Instantiate(Zombi_5, new Vector3(27, 0, 64), gameObject.transform.rotation);
        }
        else if (ButtonManager.level == 3)
        {
            Instantiate(Zombi_5, new Vector3(110, 0, 10), gameObject.transform.rotation);
            Instantiate(Zombi_5, new Vector3(110, 0, 45), gameObject.transform.rotation);
        }
        else if (ButtonManager.level == 4)
        {
            Instantiate(Zombi_5, new Vector3(205, 0, 32), gameObject.transform.rotation);
            Instantiate(Zombi_5, new Vector3(205, 0, 20), gameObject.transform.rotation);
        }
        else if (ButtonManager.level == 5)
        {
            Instantiate(Zombi_10, new Vector3(200, 0, -60), gameObject.transform.rotation);
            Instantiate(Zombi_5, new Vector3(180, 0, -60), gameObject.transform.rotation);
        }
        else if (ButtonManager.level == 6)
        {
            Instantiate(Zombi_5, new Vector3(179, 0, -131), gameObject.transform.rotation);
            Instantiate(Zombi_5, new Vector3(214, 0, -131), gameObject.transform.rotation);            
        }
        else if (ButtonManager.level == 7)
        {
            Instantiate(Zombi_5, new Vector3(274, 0, -108), gameObject.transform.rotation);
            Instantiate(Zombi_5, new Vector3(280, 0, -111), gameObject.transform.rotation);
        }
        else if (ButtonManager.level == 8)
        {
            Instantiate(Zombi_5, new Vector3(350, 0, -111), gameObject.transform.rotation);
            Instantiate(Zombi_10, new Vector3(352, 0, -113), gameObject.transform.rotation);
        }
        else if (ButtonManager.level == 9)
        {
            Instantiate(Zombi_5, new Vector3(403, 0, -108), gameObject.transform.rotation);
            Instantiate(Zombi_5, new Vector3(408, 0, -115), gameObject.transform.rotation);
            Instantiate(Zombi_5, new Vector3(400, 0, -112), gameObject.transform.rotation);
        }
        else if (ButtonManager.level == 10)
        {
            Instantiate(Zombi_10, new Vector3(478, 0, -112), gameObject.transform.rotation);
            Instantiate(Zombi_5, new Vector3(482, 0, -115), gameObject.transform.rotation);
            Instantiate(Zombi_5, new Vector3(474, 0, -109), gameObject.transform.rotation);
        }
        else
        {
            ButtonManager.level = 1; 
        }
    }
}