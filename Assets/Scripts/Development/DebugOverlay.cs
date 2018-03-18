using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void WritePlaneInformationToScreen(List<TrackedPlane> newPlanes, List<TrackedPlane> allPlanes)
    {
        if (newPlanes.Count != allPlanes.Count)
        {
            SetFoundPlanesText(string.Format("Found planes: {0}", allPlanes.Count));
        }

        if (allPlanes.Count > 0)
        {
            float[] planeSizesX = allPlanes.Select(p => p.ExtentX).ToArray();
            float[] planeSizesZ = allPlanes.Select(p => p.ExtentZ).ToArray();
            List<string> planeSizeTexts = new List<string>();
            for (int i = 0; i < allPlanes.Count; i++)
            {
                planeSizeTexts.Add(string.Format("Plane {0} size X: {1} Z: {2}", i, planeSizesX[i], planeSizesZ[i]));
            }
            SetPlaneSizesText(string.Join("\n", planeSizeTexts.ToArray()));
        }
    }

}
