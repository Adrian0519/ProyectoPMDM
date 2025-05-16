using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class finalNivel : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(CargarEscenaDespuesDeTiempo(3f));
    }

    IEnumerator CargarEscenaDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("Level2");
    }
}
