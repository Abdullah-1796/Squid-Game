using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class Wheel
{
    public WheelCollider wheelCollider;
    public Transform wheelMesh;
}

public class TankWheelController : MonoBehaviour
{
    //this class allign wheels with wheel colliders according to suspension of wheels
    public Wheel[] wheels;
    [SerializeField] private InputActionReference move;
    [SerializeField] private float maxTorque = 1500;
    [SerializeField] private float maxRotation = 2.5f;
    [SerializeField] private float brakeTorque = 10000f;

    private void FixedUpdate()
    {
        Vector2 tankMovement = move.action.ReadValue<Vector2>();
        float forward = tankMovement.y;
        float turn = tankMovement.x;

        float leftTorque = (forward - turn) * maxTorque;
        float rightTorque = (forward + turn) * maxTorque;

        for (int i = 0; i < wheels.Length; i++)
        {
            if (tankMovement.y != 0)
            {
                wheels[i].wheelCollider.brakeTorque = 0;
                if (i % 2 == 0)
                {
                    wheels[i].wheelCollider.motorTorque = leftTorque;
                }
                else
                {
                    wheels[i].wheelCollider.motorTorque = rightTorque;
                }
            }
            else
            {
                wheels[i].wheelCollider.brakeTorque = brakeTorque;
            }
        }
    }

    void Update()
    {
        foreach (var w in wheels)
        {
            UpdateWheelPosition(w.wheelCollider, w.wheelMesh);
        }
    }

    void UpdateWheelPosition(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion quat;
        collider.GetWorldPose(out pos, out quat);

        wheelTransform.position = pos;
        wheelTransform.rotation = quat;
    }
}