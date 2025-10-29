using UnityEngine;

public class Bala : MonoBehaviour
{

    [Header("Ajuestes de movimiento")]
    [SerializeField] private int velocidad;

    [Header("Tiempo de vida")]
    [SerializeField] private int tiempoVida;


    private Rigidbody2D rb;
    

    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoDisparo;
    [SerializeField] private AudioSource sonidoExplosion;


    private PuntosPowerUp puntosPowerUpClase;

    [Header("Efectos")]
    [SerializeField] private GameObject efectoImpacto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntosPowerUpClase = FindAnyObjectByType<PuntosPowerUp>();


        if(sonidoDisparo != null)
        {
            sonidoDisparo.Play();
        }
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = transform.right * velocidad;


        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (efectoImpacto != null)
            {
                Instantiate(efectoImpacto, collision.transform.position, Quaternion.identity);

                if(sonidoExplosion != null)
                {
                    sonidoExplosion.Play();
                }
            }
            puntosPowerUpClase.AddPoints(collision.gameObject.GetComponent<EnemyMove>().puntos);
            puntosPowerUpClase.MostrarPuntosDinamicos(collision.gameObject.GetComponent<EnemyMove>().puntos, collision.transform.position);

             
            Destroy(collision.gameObject);
            Destroy(gameObject, .29f);
        }
    }
}
