using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float rotationSpeed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation Code
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        //Moving code
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                speed = 5f;
            }
            else
            {
                speed = 10f;
            }
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                speed = 5f;
            }
            else
            {
                speed = 10f;
            }
            transform.position += transform.up * -speed * Time.deltaTime;
        }

        //Reducing speed with space
        
    }
}
