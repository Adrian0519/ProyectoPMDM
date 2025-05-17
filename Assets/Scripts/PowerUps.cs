using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int vidasParaSumar = 1;
    [SerializeField] private AudioClip vidaSong;

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

