using UnityEngine;
using UnityEngine.UIElements;

public class mcscript : MonoBehaviour
{
    public Rigidbody2D mcRigidbody;
    public float speed=10;
    public float jump=10;
    private bool isGrounded;
    public bool birdIsAlive = true;
    public Logic logic;

    private bool _isMoving = false;
    private bool _freezeHit = false;
    private bool _burnHit = false;

    private Animator animator;

    public bool IsFreeze
    {
        get
        {
            return _freezeHit;
        }
        set
        {
            _freezeHit = value;
            animator.SetBool("freezeHit", value);
        }
    }

    public bool IsBurn
    {
        get
        {
            return _burnHit;
        }
        set
        {
            _burnHit = value;
            animator.SetBool("burnHit", value);
        }
    }

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        set
        {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        mcRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

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
            mcRigidbody.linearVelocityX = speed;
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

        IsMoving = mcRigidbody.linearVelocityX != 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Fire"))
        {
            IsBurn = true;
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
