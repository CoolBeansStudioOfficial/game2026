using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public Sound jumpSound;
    public Sound landSound;

    public float acceleration;
    public float deceleration;
    public float maxSpeed;
    public float jumpHeight;
    public float coyoteTime;

    bool grounded = false;
    float coyoteTimeCurrent = 0f;

    void Update()
    {
        bool wasGrounded = grounded;
        grounded = IsGrounded();

        if (!wasGrounded && grounded)
        {
            if (rb.linearVelocityY <= 0f)
            {
                AudioManager.Instance.PlaySound(landSound);
            }
        }


        if (!UIManager.Instance.playerLocked)
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
                //decelerate
                rb.linearVelocityX = Mathf.MoveTowards(rb.linearVelocityX, 0, deceleration * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (coyoteTimeCurrent > 0f)
                {
                    coyoteTimeCurrent = 0f;
                    grounded = false;
                    rb.linearVelocityY = jumpHeight;

                    AudioManager.Instance.PlaySound(jumpSound);
                }
            }
        }
        else
        {
            //decelerate
            rb.linearVelocityX = Mathf.MoveTowards(rb.linearVelocityX, 0, deceleration * Time.deltaTime);
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

    bool IsGrounded()
    {
        Vector2 castPosition = rb.position;
        castPosition.y -= 0.55f;

        RaycastHit2D hit = Physics2D.Raycast(castPosition, Vector2.down);

        if (hit.collider == null) return false;
        else if (Vector2.Distance(castPosition, hit.point) < 0.001f)
        {
            return true;
        }

        

        return false;
    }
}
