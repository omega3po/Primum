using UnityEngine;

public class Player : Object
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float normalAttackSpeed = 0.05f;
    private bool isAttacking;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;

    protected override void Awake()
    {
        base.Awake(); // Call base class Awake to initialize sr
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isAttacking = false;

        if (rb == null) Debug.LogError("Rigidbody2D not found on Player");
        if (anim == null) Debug.LogError("Animator not found on Player");
    }

    protected override void Update()
    {
        base.Update(); // Call base Update to handle sorting order
        movement = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
        
        NormalAttack();
        PlayerAnimation();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement;
    }

    private void NormalAttack()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isAttacking = true;
        }

        if (isAttacking)
        {
            normalAttackSpeed -= Time.deltaTime;
        }

        if (normalAttackSpeed <= 0)
        {
            isAttacking = false;
            normalAttackSpeed = 0.05f;
        }
    }

    private void PlayerAnimation()
    {
        if (rb.linearVelocity.x > 0)
        {
            sr.flipX = false;
        }
        else if (rb.linearVelocity.x < 0)
        {
            sr.flipX = true;
        }
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isRunning", rb.linearVelocity.x != 0 || rb.linearVelocity.y != 0);
    }
}