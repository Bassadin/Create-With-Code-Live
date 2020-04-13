using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;

    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowerBound) {
            Destroy(gameObject);
        }
    }
}
