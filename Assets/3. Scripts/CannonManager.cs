using UnityEngine;

public class CannonManager : MonoBehaviour
{
    private Animation anim;
    [SerializeField] private float coolDownTime = 5f;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float rayLength = 40f;
    [SerializeField] private float rotationSpeed = 5f;

    private float time = 5;
    private bool tankFound = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = transform.parent.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(tankFound)
        {
            if (time >= coolDownTime)
            {
                time = 0;
                anim.Play();
                GameObject b = Instantiate(bullet, bulletPos.position, bullet.transform.rotation);
                Vector3 angles = b.transform.eulerAngles;
                angles.z = -transform.eulerAngles.y;
                b.transform.eulerAngles = angles;
            }
        }
        else
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        Ray ray = new Ray(bulletPos.position, bulletPos.forward);
        if(Physics.Raycast(ray, out RaycastHit hit, rayLength))
        {
            if(hit.collider.gameObject.name == "body")
            {
                tankFound = true;
            }
            else
            {
                tankFound = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(bulletPos.position, bulletPos.forward * rayLength);
    }
}
