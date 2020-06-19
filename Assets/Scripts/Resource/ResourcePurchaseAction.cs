
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

// ReSharper disable once UnusedMember.Global
// ReSharper disable once CheckNamespace
public class ResourcePurchaseAction : ResourceCovertAction
{
    public PurchaseType _PurchaseType;
    public float purchaseMultiplier = 1;
    protected override void Start()
    {
        base.Start();
        actionAmt = 0.0f;

    }

    protected override bool PerformAction()
    {
        Purchase pur = PurchaseMgr.InstanceMgr.GetPurchase(_PurchaseType);
        if (base.PerformAction())
        {
            costAmt *= pur.PurchaseModifier;
            pur.PerformPurchase();
            return true;
        }

        return false;
    }
}
