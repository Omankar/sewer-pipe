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

        // NEW BIT: tell the highlight script to do its sparkly thing
        var highlight = GetComponent<HighlightToggle>();
        if (highlight != null)
        {
            highlight.ToggleHighlight();
        }
    }
}
