using UnityEngine;
using UnityEngine.InputSystem;

public class TurretMover : MonoBehaviour
{
    [SerializeField] private InputActionReference turretMove;
    [SerializeField] private float rotationSpeed;
    
    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 turretMovement = turretMove.action.ReadValue<Vector2>();

        Debug.Log("Turret Movement: " + turretMovement);
        transform.Rotate(Vector3.up * turretMovement.x * rotationSpeed * Time.fixedDeltaTime);
    }
}
