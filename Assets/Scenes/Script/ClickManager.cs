using UnityEngine;

public class ClickManager : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var clickable = hit.collider.GetComponent<ClickableObject>();
            if (clickable == null)
                return;

            // LEFT CLICK = normal defect click (highlight + spawn distance + chart)
            if (Input.GetMouseButtonDown(0))
            {
                clickable.Click();
            }

            // RIGHT CLICK = add to selection list for pair-distance
            if (Input.GetMouseButtonDown(1))
            {
                clickable.RightClick();
            }
        }
    }
}
