﻿using UnityEngine; // Importa las funcionalidades básicas de Unity (MonoBehaviour, Vector2, etc.)

// Clase que controla el movimiento del enemigo
public class MovimientoEnemigo : MonoBehaviour
{
    // Velocidad de movimiento del enemigo. Editable desde el Inspector.
    [SerializeField] private float velocidad = 2f;
    // Prefab del power-up
    [SerializeField] private GameObject prefabPowerUp;
    // Sonido al morir
    [SerializeField] private AudioClip muerteSound;

    // Indica si el enemigo se está moviendo hacia la derecha.
    private bool moviendoDerecha = true;

    // Método llamado al iniciar el juego o al activarse el objeto.
    void Start()
    {
        // Asigna la etiqueta "Enemigo" a este GameObject
        gameObject.tag = "Enemigo";
        // No colisionan entre si
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemigos"), LayerMask.NameToLayer("Enemigos"));

    }

    // Método llamado una vez por frame
    void Update()
    {
        // Mueve al enemigo horizontalmente.
        // Si 'moviendoDerecha' es true, se mueve hacia la derecha, si no, hacia la izquierda.
        transform.Translate(Vector2.right * velocidad * Time.deltaTime * (moviendoDerecha ? 1 : -1));
    }

    // Método que se ejecuta al colisionar con otro objeto 2D
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bloqueo"))
        {
            Girar();
        }

        if (col.gameObject.CompareTag("Bala"))
        {
            // Reproducir sonido de muerte
            if (muerteSound != null)
            {
                AudioSource.PlayClipAtPoint(muerteSound, Camera.main.transform.position);
            }

            // Probabilidad del 20% de soltar power-up
            float chance = Random.Range(0f, 1f);
            if (chance <= 0.2f && prefabPowerUp != null)
            {
                Instantiate(prefabPowerUp, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); // Destruye al enemigo
            Destroy(col.gameObject); // Opcional: destruye la bala también
        }
    }

    // Método que invierte la dirección de movimiento del enemigo
    private void Girar()
    {
        // Cambia la dirección (de derecha a izquierda, o viceversa)
        moviendoDerecha = !moviendoDerecha;

        // Invierte la escala en el eje X para voltear visualmente al enemigo
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}


///-----------------------------------------------
/// ANOTACION IMPORTANTE 
/// SE CORRIGIO EL ERROR DEL ANIMATOR ASIGNANDOLE UNA ANOMACION POR DEFECTO QUE SIEMPRE USARA DEDE UNITY DE CAMINAR,
///QUE SE EJECUTARA SIEMPRE ASI NO DARA ERROR EN LA ANIMACION.
///-----------------------------------------------







