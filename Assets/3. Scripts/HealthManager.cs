using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameObject explosionOnDamage;
    [SerializeField] private GameObject cannonCounter;
    [SerializeField] private GameObject levelManager;

    public float health = 100;
    public float damageOnCollision = 10;

    private AudioSource tankExplosionAudio;

    private void Start()
    {
        tankExplosionAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cannon Bullet"))
        {
            health -= damageOnCollision;
            if(health <= 0)
            {
                Instantiate(explosionOnDamage, gameObject.transform.position, Quaternion.identity);
                Instantiate(explosionOnDamage, gameObject.transform.position, Quaternion.identity);
                Instantiate(explosionOnDamage, gameObject.transform.position, Quaternion.identity);
                Instantiate(explosionOnDamage, gameObject.transform.position, Quaternion.identity);
                tankExplosionAudio.Play();
                Debug.Log("Game Over");
                levelManager.GetComponent<LevelManager>().gameOver = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tank Missile"))
        {
            health -= damageOnCollision;
            if (health <= 0)
            {
                Instantiate(explosionOnDamage, gameObject.transform.position, Quaternion.identity);
                Instantiate(explosionOnDamage, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                cannonCounter.GetComponent<CannonCounter>().DecreaseCount();
            }
        }
    }
}
