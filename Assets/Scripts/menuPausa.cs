using UnityEngine;
using UnityEngine.UI;

public class PausaJuego : MonoBehaviour
{
    private bool juegoPausado = false;

    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuOpciones;

    [SerializeField] private Button botonReanudar;
    [SerializeField] private Button botonOpciones;
    [SerializeField] private Button botonVolver;

    void Start()
    {
        if (botonReanudar != null)
            botonReanudar.onClick.AddListener(Reanudar);

        if (botonOpciones != null)
            botonOpciones.onClick.AddListener(AbrirOpciones);

        if (botonVolver != null)
            botonVolver.onClick.AddListener(CerrarOpciones);
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
    }
}
