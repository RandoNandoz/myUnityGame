using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResourceAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("action values")] public ResourceType ActionType;

    public float actionAmt;

    protected ToolTip toolTip;

    protected Button actionButton;

    [Header("unlock condition")] public ResourceType UnlockResourceType;

    public float unlockAmt;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        actionButton = GetComponent<Button>();
        if (actionButton == null)
        {
            Debug.LogError("reose");
            return;
        }

        actionButton.onClick.AddListener(() => PerformAction());

        // turn off button gameObj
        actionButton.gameObject.SetActive(true);
        CheckState();

        // Find & operate on our tooltip obj
        toolTip = GetComponentInChildren<ToolTip>();
        if (toolTip == null)
        {
            Debug.LogError("Tooltip was not found in the children of " + gameObject.name);
            return;
        }

        LayoutGroup grGroup = GetComponentInParent<LayoutGroup>();
        grGroup.enabled = false;

        RectTransform ttRectTransform = toolTip.GetComponent<RectTransform>();
        //ttRectTransform.anchorMin = new Vector2(0.5f, 1f);
        //ttRectTransform.anchorMax = new Vector2(0.5f, 1.0f);
        ttRectTransform.SetParent(transform.parent, true);
        ttRectTransform.SetAsLastSibling();
        
        toolTip.gameObject.SetActive(false);
        grGroup.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual bool PerformAction()
    {
        ResourceManager.InstanceManager.AdjustResource(ActionType, actionAmt, true);
        return true;
    }

    public virtual void CheckState()
    {
        if (actionButton == null)
        {
            return;
        }

        Resource amt = ResourceManager.InstanceManager.GetResource(UnlockResourceType);
        if (amt.CurAmt >= unlockAmt)
        {
            actionButton.gameObject.SetActive(true);
        }
    }

    protected virtual void SetTooltip(bool visible)
    {
        if (!toolTip)
        {
            return;
        }
        toolTip.gameObject.SetActive(visible);
    }

    //void OnMouseEnter()
    //{
    //    SetTooltip(true);
    //}

    //void OnMouseExit()
    //{
    //    SetTooltip(false);
    //}

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetTooltip(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetTooltip(false);
    }
}
