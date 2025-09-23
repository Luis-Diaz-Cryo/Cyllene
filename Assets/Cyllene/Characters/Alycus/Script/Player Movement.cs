using UnityEngine;


public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    [System.Obsolete]

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
            jump();


    }

    [System.Obsolete]
    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
                   
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }




}

