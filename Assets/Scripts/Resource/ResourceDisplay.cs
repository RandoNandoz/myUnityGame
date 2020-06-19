using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;
[SuppressMessage("ReSharper", "CheckNamespace")]
// ReSharper disable once UnusedMember.Global
public class ResourceDisplay : MonoBehaviour
{
    public Text LabelText;

    public Text CurResourceText;

    public Text MaxResourceAmountText;

    public Text IncAmountText;

    public Image SymbolImage;
    // Start is called before the first frame update
    // ReSharper disable once ArrangeTypeMemberModifiers
    // ReSharper disable once UnusedMember.Local
    void Start() {}

    // Update is called once per frame
    // ReSharper disable once UnusedMember.Local
    // ReSharper disable once ArrangeTypeMemberModifiers
    void Update() {}

    private bool ret = true;
    public bool IsUiValid()
    {
        #region Error checks : Debug

        if (LabelText == null)
        {
            Debug.LogError("Missing reference for LabelText, have you applied the LabelText to the entity?");
            ret = false;
        }
        if (CurResourceText == null)
        {
            Debug.LogError("Missing reference for CurResourceText, have you applied the CurResourceText to the entity?");
            ret = false;
        }
        if (MaxResourceAmountText == null)
        {
            Debug.LogError("Missing reference for MaxResourceAmountText, have you applied the MaxResourceAmountText to the entity?");
            ret = false;
        }
        if (IncAmountText == null)
        {
            Debug.LogError("Missing reference for IncAmountText, have you applied the IncAmountText to the entity?");
            ret = false;
        }

        if (!SymbolImage)
        {
            Debug.LogError("Missing reference for SymbolImage, have you applied the SymbolImage to the entity?");
            ret = false;
        }

        return ret;

        #endregion
    }

    public void InitUi(Resource res)
    {
        if (!IsUiValid())
        {
            return;
        }

        string incOpen = (res.IncAmt >= 0.0f) ? "(+" : "(";

        LabelText.text = res.ResType.ToString();
        CurResourceText.text = res.CurAmt.ToString("N0");
        MaxResourceAmountText.text = "/" + res.MaxAmt.ToString("N0");
        IncAmountText.text = "("+ res.MaxAmt.ToString("N2") + ")";
    }

    public void Tick(float curAmt)
    {
        CurResourceText.text = curAmt.ToString("N2");

    }
}
