using UnityEngine;

public class PlayerInWaterChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in water");
        }
    }
}
