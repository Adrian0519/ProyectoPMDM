﻿using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class controladorPersonaje : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float speed = 5f;
    private float moveInput;
    private Vector3 velocity;
    private bool isGrounded;
    private Vector3 puntoInicio;


    //  Campos para disparar y audio
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private float velocidadProyectil = 10f;
    [SerializeField] private AudioClip disparoClip;
    [SerializeField] private AudioClip danhoClip;

    private AudioSource audioSource;

    void Start()
    {
        puntoInicio = transform.position; // Guarda donde inicia el personaje
        audioSource = GetComponent<AudioSource>();


    }

    void Update()
    {
        Move();
        ApplyGravity();
        Jump();

        if (Input.GetKeyDown(KeyCode.Space))
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
            animator.SetBool("Caminando",true);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-0.1402395f, 0.1435575f, 1f);
            animator.SetBool("Caminando", true);
        }
        else
        {
            animator.SetBool("Caminando", false);
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            velocity.y = jumpForce;
            transform.position += velocity * Time.deltaTime;
            isGrounded = false;
            animator.SetBool("Saltar", true);
        }
        else
        {
            animator.SetBool("Saltar", false);
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
                animator.SetTrigger("Atacando");
                float direccion = transform.localScale.x > 0 ? 1f : -1f;
                rb.linearVelocity = new Vector2(direccion * velocidadProyectil, 0f);
            }

            // Reproduce el sonido de disparo
            if (audioSource != null && disparoClip != null)
            {
                audioSource.PlayOneShot(disparoClip);
            }

            // Destruye el proyectil después de 5 segundos
            Destroy(proyectil, 5f);
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
            GameManager.Instance.SubLife(1);
            // Sonido al recibir daño
            if (audioSource != null && danhoClip != null)
            {
                audioSource.PlayOneShot(danhoClip);
            }

            Debug.Log("Vida restante: " + GameManager.Instance.GetLife());

            if (GameManager.Instance.GetLife() == 0)
            {
                Debug.Log("jugador muerto");
                SceneManager.LoadScene("GameOver");
                Destroy(gameObject); 
            }
            else
            {
                // Reaparecer en el punto inicial
                transform.position = puntoInicio;
                velocity = Vector3.zero; // Detiene el movimiento vertical
                Debug.Log("Reapareció en el punto de inicio");
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Completado"))
        {
            SceneManager.LoadScene("Transicion");
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
