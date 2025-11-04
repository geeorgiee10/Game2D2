using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMoveTopDowns : MonoBehaviour
{

    [Header("Ajustes")]
    public float moveSpeed;
    public SpriteRenderer spriteRenderer;
    public BaseFacing baseFacing = BaseFacing.Right;
    [Range(-180, 180)] public float rotationOffset = 0f;


    private Rigidbody2D rb;
    private Transform visual;
    private Vector2 move, lastDir = Vector2.up;
    const float EPS = 0.01f;


    public enum BaseFacing { Right, Left, Up, Down }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
        if (!spriteRenderer)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        visual = spriteRenderer
            ? spriteRenderer.transform
            : transform;
    }


    private void FixedUpdate()
    {
        Vector2 dir = move.sqrMagnitude > 1f
            ? move.normalized
            : move;

        rb.linearVelocity = dir * moveSpeed;
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 look =
            (move.sqrMagnitude >= EPS)
            ? move
            : rb.linearVelocity;

        if (look.sqrMagnitude >= EPS)
            lastDir = Snap4(look);


        float angle =
            AngleFromDir(lastDir)
            - BaseFacingToAngle(baseFacing)
            + rotationOffset;

        visual.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
    
    
    static float BaseFacingToAngle(BaseFacing b)
    {
        return b == BaseFacing.Right ? 0f
            : b == BaseFacing.Up ? 90f
            : b == BaseFacing.Left ? 180f
            : 270f;
    }

    static float AngleFromDir(Vector2 v)
    {
        if (v.x > 0) return 0f;
        if (v.x < 0) return 180f;
        if (v.y > 0) return 90f;
        return 270f;
    }

    static Vector2 Snap4(Vector2 v)
    {
        return Mathf.Abs(v.x) > Mathf.Abs(v.y)
            ? new Vector2(Mathf.Sign(v.x), 0f)  // devuelve (+1,0) o (-1,0)
            : new Vector2(0f, Mathf.Sign(v.y));
    }
}
