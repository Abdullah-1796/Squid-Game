using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private Animator doorAnimator;

    void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        doorAnimator.SetTrigger("Open");
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetTrigger("Close");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
