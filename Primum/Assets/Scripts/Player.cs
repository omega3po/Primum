using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movement;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
        if (rb.linearVelocity.x > 0)
        {
            sr.flipX = false;
        }
        else if (rb.linearVelocity.x < 0)
        {
            sr.flipX = true;
        }


        anim.SetBool("isRunning", (rb.linearVelocity.x != 0)||(rb.linearVelocity.y != 0));

}

    void FixedUpdate()
    {
        rb.linearVelocity = movement;
    }
}
