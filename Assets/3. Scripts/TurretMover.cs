using UnityEngine;
using UnityEngine.InputSystem;

public class TurretMover : MonoBehaviour
{
    [SerializeField] private InputActionReference turretMove;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float coolDownTime = 5f;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private GameObject bullet;

    private float time = 5;
    private AudioSource missileLaunchAudio;

    private void Start()
    {
        missileLaunchAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        Vector2 turretMovement = turretMove.action.ReadValue<Vector2>();

        //Debug.Log("Turret Movement: " + turretMovement);
        transform.Rotate(Vector3.up * turretMovement.x * rotationSpeed * Time.fixedDeltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (time >= coolDownTime)
            {
                time = 0;
                GameObject b = Instantiate(bullet, bulletPos.position, bullet.transform.rotation);
                missileLaunchAudio.Play();
                Vector3 angles = b.transform.eulerAngles;
                angles.z = -transform.eulerAngles.y;
                b.transform.eulerAngles = angles;
            }
        }
    }
}
