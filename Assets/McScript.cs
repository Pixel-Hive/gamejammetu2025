using UnityEngine;
using UnityEngine.UIElements;

public class McScript : MonoBehaviour
{
    public Rigidbody2D mcRigidbody;
    public float speed;
    public float jump;
    private bool isGrounded;
    public Logic logic;
    public bool birdIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && isGrounded && birdIsAlive)
        {
            mcRigidbody.linearVelocityY = jump;
        }

        if (Input.GetKeyDown(KeyCode.S) && isGrounded && birdIsAlive)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.y *= -1;
            transform.localScale = Scaler;
            mcRigidbody.gravityScale *= -1;
        }

        if (Input.GetKey(KeyCode.D) && birdIsAlive)
        {
            mcRigidbody.linearVelocityX = speed ;
            if (transform.localScale.x < 0)
            {
                Vector3 Scaler = transform.localScale;
                Scaler.x *= -1;
                transform.localScale = Scaler;
            }
        }

        else if (Input.GetKey(KeyCode.A) && birdIsAlive)
        {
            mcRigidbody.linearVelocityX = -speed;
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

        if (collision.gameObject.CompareTag("Death"))
        {
            birdIsAlive = false;
            logic.gameOver();
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
