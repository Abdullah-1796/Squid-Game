using UnityEngine;

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