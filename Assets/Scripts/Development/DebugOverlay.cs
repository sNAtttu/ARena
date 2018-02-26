using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugOverlay : MonoBehaviour
{
    public Text FoundPlanesText;
    public Text PlaneSizesText;

    public void SetFoundPlanesText(string text)
    {
        FoundPlanesText.text = text;
    }

    public void SetPlaneSizesText(string text)
    {
        PlaneSizesText.text = text;
    }

}
