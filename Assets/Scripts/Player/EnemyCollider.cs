using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollider : MonoBehaviour
{

    [SerializeField] private float tiempoEspera;
    private PlayerMove playerMove;
    private PlayerAnimation playerAnimation;
    private VidasJugador vidasJugador;

    private bool inmune;

    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoMuerte;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerAnimation = GetComponent<PlayerAnimation>();
        vidasJugador = GetComponent<VidasJugador>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            if(!inmune)
                StartCoroutine(PararYReiniciar());
        }
    }


    private IEnumerator PararYReiniciar()
    {
        // Time.timeScale = 0;
        inmune = true;
        Datos2.Instance.vidas--;
        vidasJugador.LoseLife();

        sonidoMuerte.Play();
        playerAnimation.AnimacionMuerte();
        yield return new WaitForSecondsRealtime(tiempoEspera);
        inmune = false;
        playerAnimation.AnimacionVida();
        if(Datos2.Instance.vidas <= 0)
        {
            playerMove.Parar();
            Datos2.Instance.vidas = 3;
            Datos2.Instance.puntos = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
