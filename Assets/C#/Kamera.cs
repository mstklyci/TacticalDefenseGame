using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Kamera : MonoBehaviour
{
    public GameObject LevelZombi;

    private void Start()
    {
        StartCoroutine(YokEt(10f));
    }

    IEnumerator YokEt(float yoket)
    {
        yield return new WaitForSeconds(yoket);
        Destroy(LevelZombi);
    }
}