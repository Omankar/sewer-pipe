using UnityEngine;

public class FogStarter : MonoBehaviour {
    void Start() {
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.ExponentialSquared; 
        RenderSettings.fogDensity = 0.01f;
        RenderSettings.fogColor = new Color(0.5f, 0.55f, 0.6f); 
    }
}
