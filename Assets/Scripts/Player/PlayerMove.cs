using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField]
    private float velocidadMovimiento = 6f;

    private Vector2 entradaMovimiento;

    private Rigidbody2D rb;

    private SpriteRenderer sprite;

    public bool mirandoDerecha = true;

    public bool enSuelo = true;

    [Header("Salto")][SerializeField] private float fuerzaSalto = 7f;

    [SerializeField] private Animator animator;

    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoSalto;
    [SerializeField] private AudioSource sonidoAndar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!sprite)
            sprite = GetComponent<SpriteRenderer>();
    }

    public void Parar()
    {
        GetComponent<PlayerInput>().enabled = false;
    }

    public bool EnSuelo()
    {
        return enSuelo;
    }


    public void OnJump(InputValue valor)
    {
        if (!enSuelo)
            return;
        if(!sonidoSalto.isPlaying)    
            sonidoSalto.Play();
        var v = rb.linearVelocity;
        v.y = 0f;
        rb.linearVelocity = v;
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
    }


    public void OnMove(InputValue valor)
    {
        entradaMovimiento = valor.Get<Vector2>();

        if (entradaMovimiento.x > 0 && !mirandoDerecha)
            Girar(false);
        else if (entradaMovimiento.x < 0 && mirandoDerecha)
            Girar(true);
    }

    private void FixedUpdate()
    {
        var v = rb.linearVelocity;
        v.x = entradaMovimiento.x * velocidadMovimiento;
        rb.linearVelocity = v;
    }


    // Update is called once per frame
    void Update()
    {
        bool estaAndando = Mathf.Abs(entradaMovimiento.x) > 0.1 && enSuelo;
        if (estaAndando)
        {
            if (!sonidoAndar.isPlaying)
            {
                sonidoAndar.Play();
            }
        }
        else
        {
            if (sonidoAndar.isPlaying)
            {
                sonidoAndar.Stop();
            }
        }
    }

    private void Girar(bool aIzquierda)
    {
        mirandoDerecha = !mirandoDerecha;
        if (sprite)
            sprite.flipX = aIzquierda;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}
