using UnityEngine;

public class JumpPlayerController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded = true;
    public float gravityModifier;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip collideSound;
    private AudioSource audioSource;

    private Rigidbody playerRigidbody;

    private Animator playerAnimator;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnimator.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            dirtParticle.Play();
        } else if (other.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            audioSource.PlayOneShot(collideSound, 1.0f);
            dirtParticle.Stop();
        }
    }
}
