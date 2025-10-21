using System.Collections;
using NUnit.Framework;
using UnityEngine;


public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Shapeshift shapeshift;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private bool facingRight = true;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dahsingCooldown = 1f;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        shapeshift = GetComponent<Shapeshift>();
    }

    [System.Obsolete]

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < -0.01f && facingRight)
        {
            Flip();
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            jump(shapeshift.formNumber);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && shapeshift.formNumber == 1)
        {
            StartCoroutine(Dash());
        }

        if (isGrounded() && !isDashing)
        {
            canDash = true;            
        }
        
            


    }

    [System.Obsolete]
    private void jump(int formNumber)
    {
        if (formNumber == 0)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
        else if (formNumber== 1)
        {
            body.velocity = new Vector2(body.velocity.x, (float)(speed * 0.8));
        }
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
                   
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    [System.Obsolete]
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dahsingCooldown);
        
    }




}

