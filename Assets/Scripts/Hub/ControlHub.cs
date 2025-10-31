using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlHub : MonoBehaviour
{


    public GameObject panelPrincipal;
    public GameObject panelCreditos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelPrincipal.SetActive(true);
        panelCreditos.SetActive(false);
    }

    public void Creditos()
    {
        panelPrincipal.SetActive(false);
        panelCreditos.SetActive(true);
    }

    public void Menu()
    {
        panelPrincipal.SetActive(true);
        panelCreditos.SetActive(false);
    }

    public void Load(string sceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError($"Escena {sceneName} no encontrada");
        }
    }


    public void SalirJuego()
    {
        Debug.Log("Salir Juego");
        Application.Quit();
    }
}
