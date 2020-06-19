using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

// ReSharper disable once UnusedMember.Global
[SuppressMessage("ReSharper", "CheckNamespace")]
public class Resource : MonoBehaviour
{
    public float CurAmt;
    public float MaxAmt;
    public float IncAmt;
    public ResourceType ResType;

    #region UnityDisabled

    //// Start is called before the first frame update
    //// ReSharper disable once UnusedMember.Local
    //// ReSharper disable once ArrangeTypeMemberModifiers
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //// ReSharper disable once UnusedMember.Local
    //// ReSharper disable once ArrangeTypeMemberModifiers
    //void Update()
    //{
        
    //}

    #endregion

    public void Tick()
    {
        AddResource(IncAmt / Constants.TICK_RATE);
    }

    public void AddResource(float amt, bool overLim = false)
    {
        float tVal = CurAmt + amt;
        CurAmt = overLim ? tVal : Mathf.Min(tVal, MaxAmt);
    }
}
