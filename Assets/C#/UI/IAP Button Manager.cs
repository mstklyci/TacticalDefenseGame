using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class IAPButtonManager : MonoBehaviour
{
    [SerializeField] private string Coins50_ID;
    [SerializeField] private GameManager gameManager;

    public void OnPurchaseComplate(Product product)
    {
        if (product.definition.id == Coins50_ID)
        {
            gameManager.GetReward(100 , false);
        }
    }


    public void OnPurcchaseFaild(Product product , PurchaseFailureDescription failureDescription)
    {
        Debug.Log(product.definition.id + "failed as a result of " + failureDescription);
    }


}