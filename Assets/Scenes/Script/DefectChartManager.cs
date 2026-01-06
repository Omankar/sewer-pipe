using UnityEngine;

public class DefectChartManager : MonoBehaviour
{
    public static DefectChartManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void ShowDefectDistance(string defectName, float distance)
    {
        Debug.Log($"[CHART] {defectName} at {distance}m");

        // TODO: plug into your UI chart here
        // Example:
        // chart.AddPoint(distance);
        // chart.Open();
    }
}
