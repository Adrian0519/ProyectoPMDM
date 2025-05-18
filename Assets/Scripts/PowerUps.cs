using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int vidasParaSumar = 1;
    [SerializeField] private AudioClip vidaSong;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Hace que el sprite parpadee
        spriteRenderer.enabled = Mathf.FloorToInt(Time.time * 5) % 2 == 0;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Jugador"))
        {
            Debug.Log("Contacto");

            GameManager.Instance.AddLife(vidasParaSumar);

            if (vidaSong != null)
            {
                GameObject tempGO = new GameObject("TempAudio");
                tempGO.transform.position = Camera.main.transform.position; // 2D -> reproducir en cámara
                AudioSource aSource = tempGO.AddComponent<AudioSource>();
                aSource.clip = vidaSong;
                aSource.Play();
                Destroy(tempGO, vidaSong.length);
            }

            Destroy(gameObject);
        }
    }
}

