using UnityEngine;

public class TankWheelBoneManager : MonoBehaviour
{
    //this class make track movement aligned with wheel of tank
    [SerializeField] private GameObject connectedWheel;
    

    // Update is called once per frame
    void Update()
    {
        if(connectedWheel != null)
        {
            transform.position = connectedWheel.transform.position;
        }
    }
}
