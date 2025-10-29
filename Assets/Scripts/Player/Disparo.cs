using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparo : MonoBehaviour
{

    [Header("Disparo")]
    [SerializeField] private GameObject prefabBala;
    [SerializeField] private Transform puntoDisparoDerecha;
    [SerializeField] private Transform puntoDisparoIzquierda;


    private PlayerMove playerMove;

    private PlayerAnimation playerAnimation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }
    

    public void OnDisparar(InputValue valor)
    {
        if (!valor.isPressed) return;

        if (prefabBala == null || puntoDisparoDerecha == null || puntoDisparoIzquierda == null)
            return;

        if(playerMove.enSuelo)
            StartCoroutine("CoorDisparo");
            
        
    }


    private IEnumerator CoorDisparo()
    {
        playerAnimation.AnimacionDisparo();

        yield return new WaitForSecondsRealtime(0.5f);

        if (playerMove.mirandoDerecha)
        {
            Instantiate(prefabBala, puntoDisparoDerecha.position, puntoDisparoDerecha.rotation);
        }
        else
        {
            Instantiate(prefabBala, puntoDisparoIzquierda.position, puntoDisparoIzquierda.rotation);
        }
    }
}
