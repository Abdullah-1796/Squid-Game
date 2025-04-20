using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;
    private bool open = false;
    private int colliderCount = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DoorFrontSide") && !open)
        {
            DoorModelReference doorModelReference = other.gameObject.GetComponent<DoorModelReference>();
            doorAnimator = doorModelReference.GetAnimator();
            doorAnimator.SetBool("locked", false);
            doorAnimator.SetBool("boxCollided", true);
            open = true;
        }
        else if (other.gameObject.CompareTag("DoorBackSide") && !open)
        {
            DoorModelReference doorModelReference = other.gameObject.GetComponent<DoorModelReference>();
            doorAnimator = doorModelReference.GetAnimator();
            doorAnimator.SetBool("locked", false);
            doorAnimator.SetBool("capsuleCollided", true);
            open = true;
        }

        if(other.gameObject.CompareTag("DoorFrontSide") || other.gameObject.CompareTag("DoorBackSide"))
        {
            colliderCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        colliderCount--;
        if (colliderCount == 0 && open)
        {
            doorAnimator.SetBool("boxCollided", false);
            doorAnimator.SetBool("capsuleCollided", false);
            Invoke("setLocked", 1f);
        }
    }

    void setLocked()
    {
        doorAnimator.SetBool("locked", true);
        open = false;
    }
}
