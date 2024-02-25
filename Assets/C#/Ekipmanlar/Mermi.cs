using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{
    public int hasar;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(100f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider nesne)
    {
        if (nesne.gameObject.CompareTag("Zombi"))
        {
            Zombie zombi = nesne.gameObject.GetComponent<Zombie>();

            if (zombi != null)
            {
                zombi.Zombican(hasar);
            }
            Destroy(gameObject);
        }
        if (nesne.gameObject.CompareTag("Varil"))
        {
            Varil varil = nesne.gameObject.GetComponent<Varil>();

            if (varil != null) 
            {
                varil.VarilHasar(hasar);
            }
            Destroy(gameObject);
        }
    }
}