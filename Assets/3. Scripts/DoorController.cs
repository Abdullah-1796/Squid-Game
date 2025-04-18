using System.Threading;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;
    private bool open = false;
    private bool closable = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            DoorModelReference doorModelReference = other.gameObject.GetComponent<DoorModelReference>();
            doorAnimator = doorModelReference.GetAnimator();
            if (other.GetType() == typeof(BoxCollider) && !open)
            {
                doorAnimator.SetBool("locked", false);
                Debug.Log("Box collider");
                doorAnimator.SetBool("boxCollided", true);
                open = true;
            }
            else if (!open)
            {
                doorAnimator.SetBool("locked", false);
                Debug.Log("Capsule collider");
                doorAnimator.SetBool("capsuleCollided", true);
                open = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (closable && open)
        {
            doorAnimator.SetBool("boxCollided", false);
            doorAnimator.SetBool("capsuleCollided", false);
            Invoke("setLocked", 1f);
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
