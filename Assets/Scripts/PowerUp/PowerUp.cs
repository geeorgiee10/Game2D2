using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUp : MonoBehaviour
{

    [Header("Audio")] public AudioSource audioSource;
    [Header("Puntuación")] public int puntosPwrUp = 10;


    private PuntosPowerUp puntosPowerUpClase;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntosPowerUpClase = FindAnyObjectByType<PuntosPowerUp>();

        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            puntosPowerUpClase.AddPoints(puntosPwrUp);
            puntosPowerUpClase.MostrarPuntosDinamicos(puntosPwrUp, transform.position);
            puntosPwrUp = 0;
            if (--other.GetComponent<ContadorPowerUps>().powerUps == 0)
            {
                if (Application.CanStreamedLevelBeLoaded("Menu"))
                {
                    SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                }
                else
                {
                    Debug.LogError($"Escena {"Menu"} no encontrada");
                }
            }
            
            if(audioSource != null){
                audioSource.Play();
                Destroy(gameObject, audioSource.clip.length/2);
            }
            else{
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
