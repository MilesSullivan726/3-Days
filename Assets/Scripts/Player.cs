using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = Vector2.zero;
        }

        if (!canMove)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * horizontalInput * Time.deltaTime * speed, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * verticalInput * Time.deltaTime * speed, ForceMode2D.Impulse);
    }

    
}
