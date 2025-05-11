using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private GameObject explosion;

    private AudioSource misileExplosionAudio;

    private void Start()
    {
        misileExplosionAudio = GameObject.Find("Level Manager").GetComponent<AudioSource>();
        misileExplosionAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * -bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tank") || collision.gameObject.name == "body")
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            misileExplosionAudio.Play();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cannon") && gameObject.CompareTag("Tank Missile"))
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            misileExplosionAudio.Play();
            Destroy(gameObject);
        }
    }
}
