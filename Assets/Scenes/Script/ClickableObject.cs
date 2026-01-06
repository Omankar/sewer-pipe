using UnityEngine;
using System.Runtime.InteropServices;

public class ClickableObject : MonoBehaviour
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void OnUnityObjectClicked(string objectName);
#endif

    public void Click()
    {
        string objName = gameObject.name;

#if UNITY_WEBGL && !UNITY_EDITOR
        OnUnityObjectClicked(objName);
#else
        Debug.Log("Clicked in Editor: " + objName);
#endif

        var highlight = GetComponent<HighlightToggle>();
        if (highlight != null)
        {
            highlight.ToggleExclusiveHighlight();
        }

        float distance = Vector3.Distance(
            PlayerSpawnTracker.SpawnPosition,
            transform.position
        );

        Debug.Log($"Defect '{objName}' distance from spawn: {distance} m");

        if (DefectChartManager.Instance != null)
        {
            DefectChartManager.Instance.ShowDefectDistance(objName, distance);
        }
    }

    public void RightClick()
    {
        if (DefectSelectionManager.Instance != null)
        {
            DefectSelectionManager.Instance.SelectDefect(transform);
        }
    }
}
