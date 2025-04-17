using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //input references
    [SerializeField] private InputActionReference movement;
    [SerializeField] private InputActionReference jump;


    //values
    [SerializeField] private float maxSpeed = 3.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float acceleration = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float rotationSpeed = 5.0f;

    //script variables
    private Rigidbody rb;
    private bool onGround = true;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        //reading value from input system
        Vector2 move = movement.action.ReadValue<Vector2>();

        //generating velocity
        Vector3 velocity = move.y * transform.forward * moveSpeed * Time.fixedDeltaTime * acceleration;

        //adding force
        rb.AddForce(velocity, ForceMode.Impulse);
        //rotation
        transform.Rotate(Vector3.up * move.x * rotationSpeed * Time.fixedDeltaTime);

        //limiting force to maxSpeed from increasing with time
        Vector3 newVelocity = rb.linearVelocity;
        Vector3 limitVelocity = Vector3.ClampMagnitude(new Vector3(newVelocity.x, 0f, newVelocity.z), maxSpeed);
        rb.linearVelocity = new Vector3 (limitVelocity.x, newVelocity.y, limitVelocity.z);
        //Debug.Log(rb.linearVelocity.x + " , " + rb.linearVelocity.z);
    }

    void Jump(InputAction.CallbackContext context)
    {
        if(onGround)
        {
            onGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnEnable()
    {
        jump.action.started += Jump;
    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Endpoint"))
        {
            Time.timeScale = 0;
            Debug.Log("Level Accomplished!");
            //move to next level
        }
    }
}
