using UnityEngine;

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
        if (Input.GetKey(KeyCode.D))
        {
            mcRigidbody.linearVelocityX = speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            mcRigidbody.linearVelocityX = -speed* Time.deltaTime;
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
