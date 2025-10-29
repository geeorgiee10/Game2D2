using UnityEngine;
using TMPro;
using System.Collections;

public class PuntosPowerUp : MonoBehaviour
{

    [Header("UI")] public Canvas canvas;
    public TextMeshProUGUI puntosText;
    public TextMeshProUGUI puntosDinamicos;


    public static PuntosPowerUp Instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         if(puntosDinamicos){
            puntosDinamicos.gameObject.SetActive(false);
        }
        ActualizarDatos();
    }

    public void ActualizarDatos()
    {
        if (puntosText)
        {
            puntosText.text = "Puntos: " + Datos2.Instance.puntos.ToString();
        }
    }
    
    public void AddPoints(int points){
        Datos2.Instance.puntos += points;
        ActualizarDatos();
    }

    public void MostrarPuntosDinamicos(int puntos, Vector3 posicionMundoPowerUp)
    {
        if(!puntosDinamicos){
            return;
        }
        puntosDinamicos.text = "+" + puntos;

        //Convertir mundo -> Pantalla
        Vector3 screenPos = Camera.main.WorldToScreenPoint(posicionMundoPowerUp + Vector3.up * 0.5f + Vector3.right * 1.5f);
        // Si el objeto está detras de la cámara, no lo mostramos
        if(screenPos.z < 0f){
            puntosDinamicos.gameObject.SetActive(false);
        }

        RectTransform rt = puntosDinamicos.rectTransform;
        if(canvas.renderMode == RenderMode.ScreenSpaceOverlay){
            rt.position = screenPos;
        }
        else{
            RectTransform canvasRT = canvas.transform as RectTransform;
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRT, 
                screenPos, 
                canvas.worldCamera, 
                out localPoint
            );
            rt.anchoredPosition = localPoint;
        }
        puntosDinamicos.gameObject.SetActive(true);
        StartCoroutine(AnimarPuntosUI(rt));

    }

    private IEnumerator AnimarPuntosUI(RectTransform rt)
    {
        float duracion = 1f;
        float t = 0f;
        Vector2 start = rt.anchoredPosition;
        while(t < duracion)
        {
            t += Time.deltaTime;
            rt.anchoredPosition = start + new Vector2(0, t * 40f);
            yield return null;
        }

        puntosDinamicos.gameObject.SetActive(false);
    }
}
