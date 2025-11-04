using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlHub : MonoBehaviour
{


    public GameObject panelPrincipal;
    public GameObject panelCreditos;
    public GameObject panelIntermedio;


    public TextMeshProUGUI puntos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Datos2.Instance == null)
        {
            panelPrincipal.SetActive(true);
            panelCreditos.SetActive(false);
            panelIntermedio.SetActive(false);
        }
        else
        {
            panelPrincipal.SetActive(false);
            panelCreditos.SetActive(false);
            panelIntermedio.SetActive(true);
            puntos.text = $"Puntos: {Datos2.Instance.puntos.ToString()}";
        }

    }
    
    public void SiguienteNivel()
    {
        Load("Nivel2");
    }

    public void PanelIntermedio(int puntos)
    {
        panelPrincipal.SetActive(false);
        panelCreditos.SetActive(false);
        panelIntermedio.SetActive(true);
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
