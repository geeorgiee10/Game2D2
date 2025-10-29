using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Posiciones")]
         private Transform puntoA;
        [SerializeField] private Transform puntoB;

    [Header("Velocidad")]
        [SerializeField] private float velocidad = 2f;

    [Header("Puntos")] public int puntos;

    private bool yendoHaciaB = true;

    private SpriteRenderer sprite;

    private void Start()
    {

        if (puntoA == null)
        {
            GameObject a = new GameObject("PuntoA_" + name);
            a.transform.position = transform.position;
            puntoA = a.transform;
        }
        

        if (!sprite)
            sprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 actual = transform.position;
        Vector2 destino = yendoHaciaB ? puntoB.position : puntoA.position;

        transform.position = Vector2.MoveTowards(actual, destino, velocidad * Time.deltaTime);

        if ((Vector2)transform.position == destino)
            yendoHaciaB = !yendoHaciaB;

        if (yendoHaciaB)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
        
    }
}
