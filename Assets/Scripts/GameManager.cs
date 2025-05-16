using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int life;
    public TextMeshProUGUI vidaPlayerGUI;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persiste entre escenas
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
        vidaPlayerGUI.text = life.ToString();
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
    }

}