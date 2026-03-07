using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundedCastPoint;

    public Sound jumpSound;

    public Vector2 groundedAngle;
    public float acceleration;
    public float deceleration;
    public float maxSpeed;
    public float jumpHeight;
    public float coyoteTime;

    bool grounded = false;
    float coyoteTimeCurrent = 0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //spawn landing particles
        if (grounded) ; 
    }

    void Update()
    {
        grounded = IsGrounded();

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
                grounded = false;
                rb.linearVelocityY = jumpHeight;

                AudioManager.Instance.PlaySound(jumpSound);
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

    bool IsGrounded()
    {
        Vector2 castPosition = rb.position;
        castPosition.y -= 0.55f;

        RaycastHit2D hit = Physics2D.Raycast(castPosition, Vector2.down);

        if (hit.collider == null) return false;
        else if (Vector2.Distance(castPosition, hit.point) < 0.001f)
        {
            print("touching ground");
            var circle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            circle.transform.position = hit.point;
            circle.transform.localScale = new(0.1f, 0.1f, 0.1f);
            return true;
        }

        

        return false;
    }
}
