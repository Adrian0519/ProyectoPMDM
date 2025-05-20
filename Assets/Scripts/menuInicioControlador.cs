using UnityEngine;
using UnityEngine.UI;
//Necesario para cambiar de escena 
using UnityEngine.SceneManagement;


public class menuInicioControlador : MonoBehaviour
{
    [SerializeField] private GameObject menuInicio;
    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject menuControles;
    [SerializeField] private Button botonControles; 
    [SerializeField] private Button botonVolverDesdeControles; 
    [SerializeField] private Button botonVolver;
    [SerializeField] private Button botonOpciones;
    [SerializeField] private Button botonSalir;
    [SerializeField] private Button botonJugar;
    [SerializeField] private Button botonPantallaCompleta;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (botonOpciones != null)
            botonOpciones.onClick.AddListener(AbrirOpciones);

        if (botonVolver != null)
            botonVolver.onClick.AddListener(CerrarOpciones);

        if (botonSalir != null)
            botonSalir.onClick.AddListener(SalirDelJuego);

        if (botonJugar != null)
            botonJugar.onClick.AddListener(IniciarJuego);

        if (botonPantallaCompleta != null)
            botonPantallaCompleta.onClick.AddListener(TogglePantallaCompleta);

        if (botonControles != null)
            botonControles.onClick.AddListener(AbrirControles);

        if (botonVolverDesdeControles != null)
            botonVolverDesdeControles.onClick.AddListener(CerrarControles);
    }


    // Update is called once per frame
    void Update()
    {

    }

    void AbrirOpciones()
    {
        menuInicio.SetActive(false);
        menuOpciones.SetActive(true);
    }

    void CerrarOpciones()
    {
        menuOpciones.SetActive(false);
        menuInicio.SetActive(true);
    }

    void AbrirControles()
    {
        menuOpciones.SetActive(false);
        menuControles.SetActive(true);
    }

    void CerrarControles()
    {
        menuControles.SetActive(false);
        menuOpciones.SetActive(true);
    }


    void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    void IniciarJuego()
    {
        Debug.Log("Cargando Nivel 1...");
        SceneManager.LoadScene("Level1"); 
    }

    //Probar pantalla completa.
    void TogglePantallaCompleta()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("Pantalla completa: " + Screen.fullScreen);
    }

}

