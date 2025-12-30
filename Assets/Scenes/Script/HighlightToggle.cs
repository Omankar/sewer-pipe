using UnityEngine;

public class HighlightToggle : MonoBehaviour
{
    private Renderer rend;
    private Material mat;
    private Color originalColor;
    private Color originalEmission;
    private bool isHighlighted = false;

    [Header("Highlight Settings")]
    [SerializeField] private Color highlightColor = Color.yellow;
    [SerializeField] private float emissionIntensity = 5f; // crank this up if needed

    void Awake()
    {
        rend = GetComponent<Renderer>();

        if (rend != null)
        {
            // make a unique material instance
            mat = rend.material;

            originalColor = mat.color;

            // store the original emission
            if (mat.IsKeywordEnabled("_EMISSION"))
                originalEmission = mat.GetColor("_EmissionColor");
            else
                originalEmission = Color.black;
        }
    }

    public void ToggleHighlight()
    {
        if (mat == null) return;

        isHighlighted = !isHighlighted;

        if (isHighlighted)
        {
            mat.color = highlightColor;

            // enable emission
            mat.EnableKeyword("_EMISSION");

            mat.SetColor("_EmissionColor", highlightColor * emissionIntensity);
        }
        else
        {
            mat.color = originalColor;

            // restore emission
            mat.SetColor("_EmissionColor", originalEmission);

            if (originalEmission == Color.black)
                mat.DisableKeyword("_EMISSION");
        }
    }
}
