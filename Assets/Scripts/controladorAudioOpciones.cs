using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; // Necesario para usar AudioMixer

public class ControladorAudioOpciones : MonoBehaviour
{
    [SerializeField] private Slider sliderVolumen;
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        float volumenGuardado = PlayerPrefs.GetFloat("volumenMusica", 1f);
        sliderVolumen.value = volumenGuardado;

        AplicarVolumen(volumenGuardado);

        sliderVolumen.onValueChanged.AddListener(AplicarVolumen);
    }

    void AplicarVolumen(float nuevoVolumen)
    {
        // Convierte de valor lineal [0,1] a dB [-80, 0]
        float volumenDB = Mathf.Log10(Mathf.Clamp(nuevoVolumen, 0.0001f, 1f)) * 20f;

        audioMixer.SetFloat("Musica", volumenDB);

        PlayerPrefs.SetFloat("volumenMusica", nuevoVolumen);
    }

    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void cambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Musica", volumen);
    }
}

