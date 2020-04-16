using UnityEngine;

public class JumpPlayerController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded = true;
    public float gravityModifier;
    public bool gameOver;

    private Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        } else if (other.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
        }
    }
}
