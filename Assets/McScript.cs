using UnityEngine;
using UnityEngine.UIElements;

public class McScript : MonoBehaviour
{
    public Rigidbody2D mcRigidbody;
    public float speed;
    public float jump;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            mcRigidbody.linearVelocityY = jump*Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S) && isGrounded)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.y *= -1;
            transform.localScale = Scaler;
            mcRigidbody.gravityScale *= -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            mcRigidbody.linearVelocityX = speed * Time.deltaTime;
            if (transform.localScale.x < 0)
            {
                Vector3 Scaler = transform.localScale;
                Scaler.x *= -1;
                transform.localScale = Scaler;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            mcRigidbody.linearVelocityX = -speed* Time.deltaTime;
            if (transform.localScale.x > 0)
            {
                Vector3 Scaler = transform.localScale;
                Scaler.x *= -1;
                transform.localScale = Scaler;
            }
        }
        else
        {
            mcRigidbody.linearVelocityX = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
