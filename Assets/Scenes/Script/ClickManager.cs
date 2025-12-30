using UnityEngine;

public class ClickManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var clickable = hit.collider.GetComponent<ClickableObject>();
                if (clickable != null)
                {
                    clickable.Click();
                }
            }
        }
    }
}