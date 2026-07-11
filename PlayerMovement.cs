using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Rotation
        if (Input.GetKey(KeyCode.LeftArrow)) { 
            rotationSpeed = 200f;
            rb.rotation += rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationSpeed = 200;
            rb.rotation -= rotationSpeed * Time.deltaTime;
        }

        else
            rotationSpeed = 0;

        // Forward movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.linearVelocity = transform.up * moveSpeed;
            if (Input.GetKey(KeyCode.Space)) // brake
                rb.linearVelocity = transform.up * (moveSpeed / 2f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.linearVelocity = transform.up * -moveSpeed;
            if (Input.GetKey(KeyCode.Space)) // brake
                rb.linearVelocity = transform.up * (-moveSpeed / 2f);
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // stop when no key pressed
        }
    }
}
