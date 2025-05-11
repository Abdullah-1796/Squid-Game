using UnityEngine;

public class CannonCounter : MonoBehaviour
{
    [SerializeField] private int cannonCount = 5;
    [SerializeField] private GameObject levelManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cannonCount == 0)
        {
            levelManager.GetComponent<LevelManager>().levelCompleted = true;
        }
    }

    public void DecreaseCount()
    {
        cannonCount--;
    }
}
