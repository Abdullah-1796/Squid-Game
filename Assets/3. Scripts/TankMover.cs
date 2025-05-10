using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class TankMover : MonoBehaviour
{
    [SerializeField] private InputActionReference move;

    //values
    [SerializeField] private float maxSpeed = 3.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float acceleration = 10.0f;
    [SerializeField] private float rotationSpeed = 5.0f;

    //script variables
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 tankMovement = move.action.ReadValue<Vector2>();


        //generating velocity
        Vector3 velocity = tankMovement.y * transform.forward * moveSpeed * acceleration * Time.fixedDeltaTime;

        //adding force
        rb.AddForce(velocity, ForceMode.Impulse);
        //rotation
        transform.Rotate(Vector3.up * tankMovement.x * rotationSpeed * Time.fixedDeltaTime);

        //limiting force to maxSpeed from increasing with time
        Vector3 newVelocity = rb.linearVelocity;
        Vector3 limitVelocity = Vector3.ClampMagnitude(new Vector3(newVelocity.x, 0f, newVelocity.z), maxSpeed);
        rb.linearVelocity = new Vector3(limitVelocity.x, newVelocity.y, limitVelocity.z);
        //Debug.Log(velocity + " , " + rb.linearVelocity.z);
    }
}
