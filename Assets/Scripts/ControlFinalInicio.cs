using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlFinalInicio : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoPantalla;
    private bool puedeContinuar = false;

    void Start()
    {
        StartCoroutine(MostrarTextoDespuesDeTiempo(3f));
    }

    void Update()
    {
        if (puedeContinuar && Input.GetKeyDown(KeyCode.Return)) // Enter
        {
            SceneManager.LoadScene("MenuInicio");
        }
    }

    IEnumerator MostrarTextoDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        if (textoPantalla != null)
        {
            textoPantalla.text = "Pulsa Enter para continuar";
        }
        puedeContinuar = true;
    }
}
