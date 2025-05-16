using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int vidasParaSumar = 1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Jugador"))
        {
            Debug.Log("Contacto");
            GameManager.Instance.AddLife(vidasParaSumar);
            Destroy(gameObject);
        }
    }
}
