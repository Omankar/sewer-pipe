using UnityEngine;
using System.Collections.Generic;

public class DefectSelectionManager : MonoBehaviour
{
    public static DefectSelectionManager Instance;

    private List<HighlightToggle> selected = new List<HighlightToggle>();

    void Awake()
    {
        Instance = this;
    }

    public void SelectDefect(Transform defect)
    {
        var highlight = defect.GetComponent<HighlightToggle>();
        if (highlight == null) return;

        // Avoid duplicates
        if (selected.Contains(highlight))
            return;

        // Add & mark BLUE
        selected.Add(highlight);
        highlight.SetSelected(true);

        Debug.Log($"Selected defect: {defect.gameObject.name}");

        if (selected.Count == 2)
        {
            CalculateDistance();
            ClearSelection();
        }
    }

    private void CalculateDistance()
    {
        Transform a = selected[0].transform;
        Transform b = selected[1].transform;

        float distance = Vector3.Distance(a.position, b.position);

        Debug.Log($"Distance between {a.gameObject.name} and {b.gameObject.name}: {distance} meters");
    }

    private void ClearSelection()
    {
        foreach (var h in selected)
            h.SetSelected(false);

        selected.Clear();
    }
}
