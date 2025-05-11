using UnityEngine;

public class PlayerInWaterChecker : MonoBehaviour
{
    [SerializeField] private GameObject levelManager;
    private AudioSource oceanAudio;

    private void Start()
    {
        oceanAudio = GetComponent<AudioSource>();
        oceanAudio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in water");
            levelManager.GetComponent<LevelManager>().gameOver = true;
        }
    }
}
