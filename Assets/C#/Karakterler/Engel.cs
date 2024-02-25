using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Engel : MonoBehaviour
{
    public float engelCan;

    private void Update()
    {
        Olme();      
    }
    
    void Olme()
    {
        if (engelCan <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        engelCan = 10 + ParaSistemi.EngelLevel;
    }
}