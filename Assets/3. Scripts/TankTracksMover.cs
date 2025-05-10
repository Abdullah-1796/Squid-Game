using UnityEngine;
using UnityEngine.InputSystem;

public class TankTracksMover : MonoBehaviour
{
    //this class rotates the texture of track only to make the illusion of track movement
    [SerializeField] private float speed = 3f;
    [SerializeField] private Material leftTread;
    [SerializeField] private Material rightTread;
    [SerializeField] private InputActionReference move;
    private float leftTreadYOffsetPos = 0f;
    private float rightTreadYOffsetPos = 0f;


    private void Update()
    {
        if (leftTread == null || rightTread == null) { return; }

        int leftTreadDir = 0;
        int rightTreadDir = 0;
        Vector2 tankMovement = move.action.ReadValue<Vector2>();
        Debug.Log(tankMovement);

        if (tankMovement.y > 0)
        {
            leftTreadDir = -1;
            rightTreadDir = -1;
        }
        if (tankMovement.y < 0)
        {
            leftTreadDir = 1;
            rightTreadDir = 1;
        }
        if (tankMovement.x < 0)
        {
            leftTreadDir = 1;
            rightTreadDir = -1;
        }
        if (tankMovement.x > 0)
        {
            leftTreadDir = -1;
            rightTreadDir = 1;
        }

        TrackScrolling(leftTreadDir, rightTreadDir);
    }

    private void TrackScrolling(int leftDir, int rightDir)
    {
        leftTreadYOffsetPos = (leftTreadYOffsetPos + (speed * Time.deltaTime * leftDir)) % 1;
        rightTreadYOffsetPos = (rightTreadYOffsetPos + (speed * Time.deltaTime * rightDir)) % 1;

        //If you use URP pipeline use this code:
        leftTread.SetVector("_UvOffset", new Vector2(0, leftTreadYOffsetPos));  //Uncomment this if you use URP pipeline
        rightTread.SetVector("_UvOffset", new Vector2(0, rightTreadYOffsetPos));  //Uncomment this if you use URP pipeline
    }
}
