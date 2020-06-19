using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Purchase : MonoBehaviour
{
    public PurchaseType PurchaseTypePurchaseTypePurchaseTypePurchaseTypePurchaseType;

    public float PurchaseModifier = 2.0f;

    public abstract void PerformPurchase();
}
