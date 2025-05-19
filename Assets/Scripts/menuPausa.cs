using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausaJuego : MonoBehaviour
{
    private bool juegoPausado = false;

    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuOpciones;

    [SerializeField] private Button botonReanudar;
    [SerializeField] private Button botonOpciones;
    [SerializeField] private Button botonVolver;
    [SerializeField] private Button botonMenuPrincipal;
    [SerializeField] private Button botonPantallaCompleta;

    void Start()
    {
        if (botonReanudar != null)
            botonReanudar.onClick.AddListener(Reanudar);

        if (botonOpciones != null)
            botonOpciones.onClick.AddListener(AbrirOpciones);

        if (botonVolver != null)
            botonVolver.onClick.AddListener(CerrarOpciones);

        if (botonMenuPrincipal != null)
            botonMenuPrincipal.onClick.AddListener(VolverAlMenuPrincipal);
        if (botonPantallaCompleta != null)
            botonPantallaCompleta.onClick.AddListener(TogglePantallaCompleta);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado && menuPausa.activeSelf)
            {
                Reanudar();
            }
            else if (!juegoPausado)
            {
                Pausar();
            }
            else if (juegoPausado && menuOpciones.activeSelf)
            {
                CerrarOpciones(); // Si estás en opciones y pulsas ESC, vuelve al menú pausa
            }
        }
    }

    void Pausar()
    {
        Time.timeScale = 0f;
        juegoPausado = true;
        menuPausa.SetActive(true);
        menuOpciones.SetActive(false);
        Debug.Log("Juego pausado");
    }

    void Reanudar()
    {
        Time.timeScale = 1f;
        juegoPausado = false;
        menuPausa.SetActive(false);
        menuOpciones.SetActive(false);
        Debug.Log("Juego reanudado");
    }

    void AbrirOpciones()
    {
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
    }

    void CerrarOpciones()
    {
        menuOpciones.SetActive(false);
        menuPausa.SetActive(true);
        botonOpciones.gameObject.SetActive(true);
    }
    void VolverAlMenuPrincipal()
    {
        Time.timeScale = 1f; //Restablecer el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MenuInicio"); // Asegúrate de que esta escena exista
    }
    void TogglePantallaCompleta()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("Pantalla completa: " + Screen.fullScreen);
    }
}
