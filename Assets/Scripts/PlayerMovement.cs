using Unity.VisualScripting;
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
        grounded = IsGrounded(collision);
        if (grounded) print("touching ground");
        else print("not touching ground");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = IsGrounded(collision);
        if (grounded) print("touching ground");
        else print("not touching ground");
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
                coyoteTimeCurrent = 0f;
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

    bool IsGrounded(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            if (collision.GetContact(i).normal == groundedAngle) return true;
        }

        return false;
    }
}
