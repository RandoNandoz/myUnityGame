
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
[SuppressMessage("ReSharper", "CheckNamespace")]
// ReSharper disable once UnusedMember.Global
public class ResourceCovertAction : ResourceAction

{
    [Header("resource cost")] public ResourceType CostType;
    public float costAmt;
    protected override bool PerformAction() 
    {
        Resource floatAmt = ResourceManager.InstanceManager.GetResource(CostType);
        if (floatAmt.CurAmt >= costAmt)
        {
            
            ResourceManager.InstanceManager.AdjustResource(CostType, -costAmt);
            return base.PerformAction();
        }

        return false;
    }

    public override void CheckState()
    {
        base.CheckState();
        Resource amt = ResourceManager.InstanceManager.GetResource(UnlockResourceType);
        if (actionButton != null)
        {
            if (actionButton.gameObject.activeSelf)
            {
                actionButton.interactable = (amt.CurAmt >= costAmt);
            }
        }
    }

    protected override void SetTooltip(bool visible)
    {
        if (!toolTip)
        {
            return;
        }
        base.SetTooltip(visible);
        toolTip.UpdateText(this);
    }
}
