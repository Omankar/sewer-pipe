using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Save the original spawn position + rotation
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        // Press R to reset the player
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayer();
        }
    }

    public void ResetPlayer()
    {
        if (controller != null)
        {
            // Disable controller so teleport works properly
            controller.enabled = false;
        }

        transform.position = startPosition;
        transform.rotation = startRotation;

        if (controller != null)
        {
            // Re-enable after teleport
            controller.enabled = true;
        }
    }
}
