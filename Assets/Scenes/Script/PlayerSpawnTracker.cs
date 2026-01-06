using UnityEngine;

public class PlayerSpawnTracker : MonoBehaviour
{
    public static Vector3 SpawnPosition;

    void Start()
    {
        SpawnPosition = transform.position;
    }
}
