using UnityEngine;
using UnityEngine.InputSystem;
public class CarController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float throttle = 0f;
    float steer = 0f;
    float acceleration = 10f;
    float max_speed = 15f;
    float steering = 220f;
    Vector2 move;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Debug.Log("Hello From Car");
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        throttle = Input.GetAxisRaw("Vertical");
        steer = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        Vector2 forward = transform.up;
        rb.AddForce(forward * throttle * acceleration, ForceMode2D.Force);
        
        if (rb.linearVelocity.magnitude > max_speed)
            rb.linearVelocity = rb.linearVelocity.normalized * max_speed;

        float turn = -steer * steering * Time.fixedDeltaTime;
        

        rb.MoveRotation(rb.rotation + turn);   
    }
}
