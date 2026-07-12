using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject missilePrefab; // drag your prefab here
    public Transform firePoint;      // empty GameObject where missile spawns
    public float baseSpeed = 10f;
    public float maxSpeed = 30f;

    private float chargeTimer = 0f;

    void Update()
    {
        // Hold Space to charge
        if (Input.GetKey(KeyCode.Space))
        {
            chargeTimer += Time.deltaTime;
        }

        // Release Space to fire
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Create a clone at firePoint’s position and rotation
            GameObject missileClone = Instantiate(missilePrefab, firePoint.position, (firePoint.rotation));
            Rigidbody2D rb = missileClone.GetComponent<Rigidbody2D>();
            rb.linearVelocity = firePoint.up * 20f;

            // Reset charge
            chargeTimer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            Destroy(gameObject); // delete this missile clone
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // delete when off screen
    }

}
