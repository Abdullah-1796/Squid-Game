using UnityEngine;

public class PlayerInWaterChecker : MonoBehaviour
{
    [SerializeField] private GameObject levelManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in water");
            levelManager.GetComponent<LevelManager>().gameOver = true;
        }
    }
}
