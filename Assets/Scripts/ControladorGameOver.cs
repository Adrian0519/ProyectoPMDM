using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorGameOver : MonoBehaviour
{
    [SerializeField] private Button botonReiniciar;
    [SerializeField] private Button botonSalir;

    void Start()
    {
        botonReiniciar.onClick.AddListener(ReiniciarNivel);
        botonSalir.onClick.AddListener(SalirAlMenu);
    }

    private void ReiniciarNivel()
    {
        //Setear las vidas a 0 para evitar un bucle al reiniciar el nivel.
        GameManager.Instance.ReiniciarEstado();
        SceneManager.LoadScene("Level1");
    }

    private void SalirAlMenu()
    {
        SceneManager.LoadScene("MenuInicio"); 
    }
}

