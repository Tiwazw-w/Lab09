using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; // Fuerza del salto
    public float moveSpeed = 5f; // Velocidad de movimiento lateral
    public Transform groundCheck; // Punto de comprobación de si está en el suelo
    public LayerMask groundLayer; // Capa del suelo

    private Rigidbody2D rb;
    private Quaternion downRotation;
    private Quaternion forwardRotation;
    private bool isGrounded;
    private bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
    }

    void Update()
    {
        isGrounded = IsGrounded();
        RotatePlayer();

        float moveInput = Input.acceleration.x;
        MovePlayer(moveInput * moveSpeed);

        if (isGrounded && canJump)
        {
            Jump();
            canJump = false;
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    void RotatePlayer()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, isGrounded ? downRotation : forwardRotation, 5f * Time.deltaTime);
    }

    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void MovePlayer(float move)
    {
        Vector2 movement = new Vector2(move, rb.velocity.y);
        rb.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Plataforma"))
        {
            canJump = true;
        }
        else if (col.gameObject.CompareTag("Perder"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        gameObject.SetActive(false);
    }
}




