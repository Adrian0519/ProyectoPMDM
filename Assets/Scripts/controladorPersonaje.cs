using UnityEngine;

public class controladorPersonaje : MonoBehaviour
{
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float speed = 5f;
    private float moveInput;
    private Vector3 velocity;
    private bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        
        Move();
        ApplyGravity();
        Jump();
    }

    private void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // Movimiento en X
        Vector3 movement = new Vector3(moveInput, 0f, 0f);
        transform.position += movement * speed * Time.deltaTime;

        // Girar el personaje con las escalas que pasaste
        if (moveInput > 0) // Derecha
        {
            transform.localScale = new Vector3(0.1402395f, 0.1435575f, 1f);
        }
        else if (moveInput < 0) // Izquierda
        {
            transform.localScale = new Vector3(-0.1402395f, 0.1435575f, 1f);
        }       
    }
    private void ApplyGravity()
    {
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpForce;
            transform.position += velocity * Time.deltaTime;
            isGrounded = false;
        }
    }

    // Detectar cuando tocamos el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Pinchos"))
        {
            Debug.Log("muerto");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("muerto");
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Completado"))
        {
            Debug.Log("COMPLETADO");
        }
    }

    // Detectar cuando dejamos de tocar el suelo
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            isGrounded = false;
        }
    }

    
}
