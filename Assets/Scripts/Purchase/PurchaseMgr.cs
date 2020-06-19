using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PurchaseMgr : MonoBehaviour
{
    private List<Purchase> purchases = new List<Purchase>();

    public static PurchaseMgr InstanceMgr;

    void Awake()
    {
        if (InstanceMgr != null)
        {
            Destroy(gameObject);
        }
        else
        {
            InstanceMgr = this; 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        purchases = GetComponentsInChildren<Purchase>().ToList();
    }

    void Update()
    {
        
    }

    public Purchase GetPurchase(PurchaseType type)
    {
        foreach (var p in purchases)
        {
            if (p.PurchaseTypePurchaseTypePurchaseTypePurchaseTypePurchaseType == type)
            {
                return p;
            }
        }

        return null;
    }
}
