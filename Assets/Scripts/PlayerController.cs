using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float xRange = 12f;
    public float zRange = 1.5f;

    public GameObject projectilePrefab;

    void Start()
    {

    }

    void Update()
    {
        handleMovement();
        handleShooting();
    }

    void handleMovement()
    {
        // Horizontal
        float horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.x < -xRange)
        {
            horizontalInput = Mathf.Clamp(horizontalInput, 0, 1);
        }

        if (transform.position.x > xRange)
        {
            horizontalInput = Mathf.Clamp(horizontalInput, -1, 0);
        }

        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Vertical
        float verticalInput = Input.GetAxis("Vertical");

        if (transform.position.z < -zRange)
        {
            verticalInput = Mathf.Clamp(verticalInput, 0, 1);
        }

        if (transform.position.z > zRange)
        {
            verticalInput = Mathf.Clamp(verticalInput, -1, 0);
        }

        transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);
    }

    void handleShooting() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
