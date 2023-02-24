
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public float jumpForce = 10f; // Player jump force
    public Transform groundCheck; // Ground check object
    public float groundCheckRadius = 0.1f; // Radius of ground check sphere
    public LayerMask whatIsGround; // Ground layer mask

    private Rigidbody2D rb; // Player's Rigidbody2D component
    private bool isGrounded; // Is the player on the ground?

    private SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Get horizontal input
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Move the player horizontally
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the player's sprite based on movement direction
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void Update()
    {
        // Check if the jump button is pressed and the player is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply upward force to the player
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        // Check if the player collided with the spike
        if (col.gameObject.CompareTag("Spike"))
        {
            // Reset the scene
            sr.color = new Color(1f, 0f, 0f);
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    
}