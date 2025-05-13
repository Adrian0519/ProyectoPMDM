using UnityEngine; // Importa las funcionalidades básicas de Unity (MonoBehaviour, Vector2, etc.)

// Clase que controla el movimiento del enemigo
public class MovimientoEnemigo : MonoBehaviour
{
    // Velocidad de movimiento del enemigo. Editable desde el Inspector.
    [SerializeField] private float velocidad = 2f;

    // Indica si el enemigo se está moviendo hacia la derecha.
    private bool moviendoDerecha = true;
    private Animation caminarEnemigo;
    Animator anim = null;

    // Método llamado al iniciar el juego o al activarse el objeto.
    void Start()
    {
        // Asigna la etiqueta "Enemigo" a este GameObject
        gameObject.tag = "Enemigo";
        anim = GetComponent<Animator>();
    }

    // Método llamado una vez por frame
    void Update()
    {
        // Mueve al enemigo horizontalmente.
        // Si 'moviendoDerecha' es true, se mueve hacia la derecha, si no, hacia la izquierda.
        transform.Translate(Vector2.right * velocidad * Time.deltaTime * (moviendoDerecha ? 1 : -1));
        caminarEnemigo.Play();
    }

    // Método que se ejecuta al colisionar con otro objeto 2D
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bloqueo"))
        {
            Girar();
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




