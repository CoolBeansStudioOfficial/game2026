using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 groundedAngle;
    public float acceleration;
    public float deceleration;
    public float maxSpeed;
    public float jumpHeight;
    public float coyoteTime;

    bool grounded = false;
    float coyoteTimeCurrent = 0f;

    void OnCollisionStay2D(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            grounded = IsGrounded(collision.GetContact(i).normal);
            if (grounded) break;
        }
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX -= acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX += acceleration * Time.deltaTime;
        }
        else
        {
            rb.linearVelocityX = Mathf.MoveTowards(rb.linearVelocityX, 0, deceleration * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (coyoteTimeCurrent > 0f)
            {
                grounded = false;
                rb.linearVelocityY = jumpHeight;
            }
        }

        //coyote time countdown
        if (!grounded)
        {
            coyoteTimeCurrent -= Time.deltaTime;
            if (coyoteTimeCurrent < 0f) coyoteTimeCurrent = 0f;
        }
        else
        {
            coyoteTimeCurrent = coyoteTime;
        }

        //speed cap
        rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -maxSpeed, maxSpeed);
    }

    bool IsGrounded(Vector2 normal)
    {
        if (normal == groundedAngle) return true;
        else return false;
    }
}
