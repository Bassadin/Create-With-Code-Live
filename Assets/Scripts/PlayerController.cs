using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float moveSpeed = 5f;

    public float xRange = 12f;

    void Start()
    {

    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.x < -xRange)
        {
            horizontalInput = Mathf.Clamp(horizontalInput, 0, 1);
        }

        if (transform.position.x > xRange)
        {
            horizontalInput = Mathf.Clamp(horizontalInput, -1, 0);
        }

        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
    }
}
