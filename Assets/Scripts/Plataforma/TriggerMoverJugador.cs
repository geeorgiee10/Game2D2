using UnityEngine;

public class TriggerMoverJugador : MonoBehaviour
{
    [SerializeField] string etiquetaJugador = "Player";
    [SerializeField] Transform plataforma;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(etiquetaJugador))
        {
            collision.gameObject.transform.parent = plataforma;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(etiquetaJugador))
        {
            if(collision.transform != null && transform != null &&
            collision.gameObject.activeInHierarchy && gameObject.activeInHierarchy)
            {
                collision.gameObject.transform.parent = null;
            }
        }
    }
}
