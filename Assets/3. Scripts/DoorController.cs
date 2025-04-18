using System.Threading;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private Animator doorAnimator;
    private bool open = false;
    private bool closable = false;

    void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        doorAnimator.SetBool("locked", false);
        if (other.GetType() == typeof(BoxCollider) && !open)
        {
            doorAnimator.SetBool("boxCollided", true);
            open = true;
        }
        else if(!open)
        {
            doorAnimator.SetBool("capsuleCollided", true);
            open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (closable)
        {
            doorAnimator.SetBool("boxCollided", false);
            doorAnimator.SetBool("capsuleCollided", false);
            Invoke("setLocked", 2f);
            closable = false;
        }
        else
        {
            closable = true;
        }
    }

    void setLocked()
    {
        doorAnimator.SetBool("locked", true);
        open = false;
    }
}
