using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingPurchases : Purchase
{
    [HideInInspector]
    public int PurchaseCount = 0;

    public ResourceType ResourceTypesResourceType;

    public float PurchaseFactor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PerformPurchase()
    {
        PurchaseCount++;
        Resource res = ResourceManager.InstanceManager.GetResource(ResourceTypesResourceType);
        if (res)
        {
            res.IncAmt += PurchaseFactor;
            ResourceManager.InstanceManager.UpdateResourceDisplay(ResourceTypesResourceType);
        }
    }
}
