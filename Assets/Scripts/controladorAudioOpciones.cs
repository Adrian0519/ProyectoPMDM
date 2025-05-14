using UnityEngine;
using UnityEngine.UI;

public class ControladorAudioOpciones : MonoBehaviour
{
    [SerializeField] private Slider sliderVolumen;
    [SerializeField] private AudioSource fuenteAudio;
    private void Update()
    {
        
    }
    void Start()
    {
        // Cargar volumen guardado o usar 1 por defecto
        float volumenGuardado = PlayerPrefs.GetFloat("volumenMusica", 1f);
        sliderVolumen.value = volumenGuardado;

        AplicarVolumen(volumenGuardado);

        sliderVolumen.onValueChanged.AddListener(AplicarVolumen);
    }

    void AplicarVolumen(float nuevoVolumen)
    {
        if (fuenteAudio != null)
        {
            fuenteAudio.volume = nuevoVolumen;
        }

        PlayerPrefs.SetFloat("volumenMusica", nuevoVolumen);
    }
}

