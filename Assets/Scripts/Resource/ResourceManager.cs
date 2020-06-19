using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using System.Linq;

[SuppressMessage("ReSharper", "CheckNamespace")]
// ReSharper disable once UnusedMember.Global
public class ResourceManager : MonoBehaviour
{
    [System.Serializable]
    public struct ResourceController
    {
        // ReSharper disable once InconsistentNaming
        public Resource resource;
        public ResourceDisplay Display;
    }

    public List<ResourceController> ResourcesList;

    private float TickTimer = 0.0f;

    // Lazy singleton
    public static ResourceManager InstanceManager;

    public GameObject ActionRootGameObject;

    private List<ResourceAction> actions = new List<ResourceAction>();
    // ReSharper disable once ArrangeTypeMemberModifiers
    // ReSharper disable once UnusedMember.Local
    void Awake()
    {
        if (InstanceManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            InstanceManager = this;
        }
    }
    // Start is called before the first frame update
    // ReSharper disable once UnusedMember.Local
    // ReSharper disable once ArrangeTypeMemberModifiers
    void Start()
    {
        if (ActionRootGameObject)
        {
            actions = ActionRootGameObject.GetComponentsInChildren<ResourceAction>(true).ToList();
        }

        ResourcesList.ForEach(rc => rc.Display.InitUi(rc.resource));
    }

    // Update is called once per frame
    // ReSharper disable once UnusedMember.Local
    // ReSharper disable once ArrangeTypeMemberModifiers
    void Update()
    {
        TickTimer += Time.deltaTime;
        while (TickTimer >= Constants.TICK_INTERVAL)
        {
            TickTimer -= Constants.TICK_INTERVAL;
            Tick();
            actions.ForEach((act) => act.CheckState());
        }
    }

    private void Tick()
    {
        // Lambda expressions for the foreach loop.
        ResourcesList.ForEach((rc) =>
        {
            rc.resource.Tick();
            rc.Display.Tick(rc.resource.CurAmt);
        });
    }

    public void AdjustResource(ResourceType type, float amt, bool overLim = false)
    {
        foreach (var resourceController in ResourcesList)
        {
            if (resourceController.resource.ResType == type)
            {
                Debug.Log("Adjusting: " + amt + " of type " + type);
                resourceController.resource.AddResource(amt, overLim);
                resourceController.Display.Tick(resourceController.resource.CurAmt);
                break;
            }
        }
    }

    public Resource GetResource(ResourceType type)
    {
        foreach (var resourceController in ResourcesList)
        {
            if (resourceController.resource.ResType == type)
            {
                return resourceController.resource;
            }
            
        }

        return null;
    }

    public void UpdateResourceDisplay(ResourceType type)
    {
        foreach (var resourceController in ResourcesList)
        {
            if (resourceController.resource.ResType == type)
            {
                resourceController.Display.InitUi(resourceController.resource);
                return;
            }
        }
    }
}
