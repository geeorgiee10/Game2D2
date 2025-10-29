using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{

    [Header("Componentes")]
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    private PlayerMove playerMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<PlayerMove>();
    }

    public void AnimacionMuerte()
    {
        animator.SetTrigger("Muerte");
    }

    public void AnimacionVida()
    {
        animator.SetTrigger("VidaNueva");
    }

    public void AnimacionDisparo()
    {
        animator.ResetTrigger("Disparar");
        animator.SetTrigger("Disparar");
    }

    public void OnMove(InputValue value)
    {
        animator.SetFloat("x", Mathf.Abs(value.Get<Vector2>().x));
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("y", rb.linearVelocity.y);
        animator.SetBool("enSuelo", playerMove.EnSuelo());
    }
}
