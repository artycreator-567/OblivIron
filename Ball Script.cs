using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject missilePrefab; // drag your prefab here
    public Transform firePoint;      // empty GameObject where missile spawns
    public float baseSpeed = 10f;
    public float maxSpeed = 30f;


    void Update()
    {
        // Hold Space to charge
        if (Input.GetKey(KeyCode.Space))
        {
            baseSpeed += Time.deltaTime;
            if (baseSpeed == maxSpeed)
                baseSpeed = maxSpeed;
        }

        // Release Space to fire
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Create a clone at firePoint’s position and rotation
            GameObject missileClone = Instantiate(missilePrefab, firePoint.position, (firePoint.rotation));
            Rigidbody2D rb = missileClone.GetComponent<Rigidbody2D>();
            rb.linearVelocity = firePoint.up * baseSpeed;

            // Reset charge
            baseSpeed = 10f;
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
