using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalBoss : MonoBehaviour
{
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private int vida = 3;
    [SerializeField] private float fuerzaSalto = 7f;
    [SerializeField] private GameObject prefabPowerUp;
    [SerializeField] private AudioClip muerteSound;
    [SerializeField] private float duracionColorDaño = 0.2f;

    private bool moviendoDerecha = true;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Color colorOriginal;

    void Start()
    {
        gameObject.tag = "Enemigo";
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            colorOriginal = sr.color;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemigos"), LayerMask.NameToLayer("Enemigos"));
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime * (moviendoDerecha ? 1 : -1));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bloqueo"))
        {
            Girar();
        }

        if (col.CompareTag("Bala"))
        {
            vida--;
            Destroy(col.gameObject);
            Saltar();
            StartCoroutine(EfectoDaño());

            if (vida <= 0)
            {
                Morir();
            }
        }
    }

    private System.Collections.IEnumerator EfectoDaño()
    {
        if (sr != null)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(duracionColorDaño);
            sr.color = colorOriginal;
        }
    }

    private void Saltar()
    {
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }

    private void Morir()
    {
        if (muerteSound != null)
        {
            AudioSource.PlayClipAtPoint(muerteSound, Camera.main.transform.position);
        }

        if (prefabPowerUp != null && Random.Range(0f, 1f) <= 0.2f)
        {
            Instantiate(prefabPowerUp, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
        SceneManager.LoadScene("EscenaFinal");
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}



