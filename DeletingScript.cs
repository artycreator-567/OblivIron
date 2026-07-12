using UnityEngine;

public class DeletingScript : MonoBehaviour
{
    public GameObject flashPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit enemy!");
            Instantiate(flashPrefab, collision.transform.position, Quaternion.identity);

            // Destroy the enemy
            Destroy(collision.gameObject);

            // Destroy the bullet itself
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
