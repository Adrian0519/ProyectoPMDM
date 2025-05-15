using UnityEngine;

public class controladorPersonaje : MonoBehaviour
{
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float speed = 5f;
    private float moveInput;
    private Vector3 velocity;
    private bool isGrounded;

    // ?? Campos para disparar
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private float velocidadProyectil = 10f;

    void Update()
    {
        Move();
        ApplyGravity();
        Jump();

        // Disparo
        if (Input.GetButtonDown("Fire1")) // Clic izquierdo o Ctrl por defecto
        {
            Disparar();
        }
    }

    private void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // Movimiento en X
        Vector3 movement = new Vector3(moveInput, 0f, 0f);
        transform.position += movement * speed * Time.deltaTime;

        // Girar el personaje con las escalas que pasaste
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(0.1402395f, 0.1435575f, 1f);
        }
        else if (moveInput < 0)
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

    private void Disparar()
    {
        if (proyectilPrefab != null && puntoDisparo != null)
        {
            GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);

            Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float direccion = transform.localScale.x > 0 ? 1f : -1f;
                rb.velocity = new Vector2(direccion * velocidadProyectil, 0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Pinchos") || collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("muerto");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Completado"))
        {
            Debug.Log("COMPLETADO");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            isGrounded = false;
        }
    }
}
