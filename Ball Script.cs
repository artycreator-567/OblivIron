using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    public Transform target = null;
    public bool shot = false;
    public float bulletSpeed = 15.0f;
    [SerializeField]
    public GameObject Circle;
    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shot != true)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            bulletSpeed += (Time.deltaTime*5);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            shot = true;
            GameObject missileClone = Instantiate(
                Circle,
                target.position,
                target.rotation
            );
        }

        if (shot == true)
        {
            Rigidbody2D rb = Circle.GetComponent<Rigidbody2D>();
            rb.linearVelocity = target.up * bulletSpeed;
        }
    }

}
