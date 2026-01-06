using UnityEngine;

public class HighlightToggle : MonoBehaviour
{
    private static HighlightToggle currentlyHighlighted;

    private Renderer rend;
    private Material mat;
    private Color originalColor;
    private Color originalEmission;

    [Header("Highlight Settings")]
    [SerializeField] private Color highlightColor = Color.yellow;
    [SerializeField] private Color selectionColor = Color.cyan;
    [SerializeField] private float emissionIntensity = 3f;

    private bool isHighlighted = false;
    private bool isSelected = false;

    void Awake()
    {
        rend = GetComponent<Renderer>();

        if (rend != null)
        {
            mat = rend.material;
            originalColor = mat.color;

            if (mat.IsKeywordEnabled("_EMISSION"))
                originalEmission = mat.GetColor("_EmissionColor");
            else
                originalEmission = Color.black;
        }
    }

    // ---------- LEFT CLICK (YELLOW EXCLUSIVE) ----------
    public void ToggleExclusiveHighlight()
    {
        if (currentlyHighlighted == this)
        {
            DeactivateHighlight();
            currentlyHighlighted = null;
            return;
        }

        if (currentlyHighlighted != null)
        {
            currentlyHighlighted.DeactivateHighlight();
        }

        ActivateHighlight();
        currentlyHighlighted = this;
    }

    private void ActivateHighlight()
    {
        if (mat == null) return;

        isHighlighted = true;

        mat.color = highlightColor;
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", highlightColor * emissionIntensity);
    }

    private void DeactivateHighlight()
    {
        if (mat == null) return;

        isHighlighted = false;

        // Restore ONLY if not selected
        if (!isSelected)
        {
            mat.color = originalColor;
            mat.SetColor("_EmissionColor", originalEmission);

            if (originalEmission == Color.black)
                mat.DisableKeyword("_EMISSION");
        }
    }

    // ---------- RIGHT CLICK (BLUE SELECTION) ----------
    public void SetSelected(bool value)
    {
        isSelected = value;

        if (isSelected)
        {
            mat.color = selectionColor;
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", selectionColor * emissionIntensity);
        }
        else
        {
            // If yellow highlight is active, keep it
            if (isHighlighted)
            {
                mat.color = highlightColor;
                mat.SetColor("_EmissionColor", highlightColor * emissionIntensity);
            }
            else
            {
                mat.color = originalColor;
                mat.SetColor("_EmissionColor", originalEmission);

                if (originalEmission == Color.black)
                    mat.DisableKeyword("_EMISSION");
            }
        }
    }
}
