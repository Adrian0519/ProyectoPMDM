using UnityEngine;
using UnityEngine.UI;

public class PausaJuego : MonoBehaviour
{
    // booleano para saber si esta pausado
    private bool juegoPausado = false;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject Menu;
    [SerializeField] private Button reanudarButton;

    void Start()
    {
        
        if (reanudarButton != null)
        {
            reanudarButton.onClick.AddListener(Reanudar); 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    void Pausar()
    {
        Time.timeScale = 0f;
        juegoPausado = true;
        Debug.Log("Juego pausado");
        // Activar el menú de pausa (Canvas)
        menuPausa.SetActive(true);
        Menu.SetActive(true);

    }

    void Reanudar()
    {
        Time.timeScale = 1f;
        juegoPausado = false;
        Debug.Log("Juego reanudado");
        // Desactivar el menú de pausa (Canvas)
        menuPausa.SetActive(false);
        Menu.SetActive(false);
    }
}

