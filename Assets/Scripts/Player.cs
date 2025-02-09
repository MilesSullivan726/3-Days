using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    public bool canMove = true;
    private bool facingFront;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            facingFront = false;
            animator.SetTrigger("WalkBack");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            facingFront = true;
            
            animator.SetTrigger("WalkFront");
        }

        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;
            if (facingFront)
            {
                animator.SetTrigger("WalkFront");
            }
            else
            {
                animator.SetTrigger("WalkBack");
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            if (facingFront)
            {
                animator.SetTrigger("WalkFront");
            }
            else
            {
                animator.SetTrigger("WalkBack");
            }
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector2.zero;
            if (facingFront)
            {
                animator.SetTrigger("Idle");
            }
            else
            {
                animator.SetTrigger("IdleBack");
            }
        }



        if (!canMove)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * horizontalInput * Time.deltaTime * speed, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * verticalInput * Time.deltaTime * speed, ForceMode2D.Impulse);
    }


    
    
}
