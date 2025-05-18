using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int life;
    private TextMeshProUGUI vidaPlayerGUI;
    private bool yaInicializado = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persiste entre escenas
            SceneManager.sceneLoaded += OnSceneLoaded; // Escuchar cambios de escena para el GameOver
        }
        else
        {
            Destroy(gameObject); // evita duplicados
        }
    }

    void Start()
    {
        life = 3;
    }

    void Update()
    {
        ActualizarUI();
    }

    public void SubLife(int n)
    {
        Debug.Log("sublife");
        SetLife(n);
    }

    public int GetLife()
    {
        Debug.Log("getlife");
        return life;
    }

    public void SetLife(int l)
    {
        Debug.Log("setlife");
        life -= l;
    }

    public void AddLife(int l)
    {
        life += l;
    }

    public void ReiniciarEstado()
    {
        life = 3;
        yaInicializado = true;
        ActualizarUI();
    }

    private void ActualizarUI()
    {
        if (vidaPlayerGUI != null)
        {
            vidaPlayerGUI.text = life.ToString();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameOver")
        {
            Destroy(gameObject); //Esto hace que el GameManager se destruya al cargar GameOver
        }
        else
        {
            if (scene.name == "Level1" || scene.name == "Level2")
            {
                life = 3;
            }
            // Busca el componente UI en cada nueva escena para que la ui se muestre correctamente.
            vidaPlayerGUI = GameObject.FindWithTag("VidaUI")?.GetComponent<TextMeshProUGUI>();
            ActualizarUI();
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}