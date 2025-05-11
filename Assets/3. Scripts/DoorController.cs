using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;
    private bool open = false;
    private int colliderCount = 0;
    private AudioSource[] doorAudio;

    private void Start()
    {
        doorAudio = GetComponents<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DoorFrontSide") && !open)
        {
            DoorModelReference doorModelReference = other.gameObject.GetComponent<DoorModelReference>();
            doorAnimator = doorModelReference.GetAnimator();
            doorAnimator.SetBool("locked", false);
            doorAnimator.SetBool("boxCollided", true);
            open = true;
            doorAudio[0].Play();
        }
        else if (other.gameObject.CompareTag("DoorBackSide") && !open)
        {
            DoorModelReference doorModelReference = other.gameObject.GetComponent<DoorModelReference>();
            doorAnimator = doorModelReference.GetAnimator();
            doorAnimator.SetBool("locked", false);
            doorAnimator.SetBool("capsuleCollided", true);
            open = true;
            doorAudio[0].Play();
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
        doorAudio[1].Play();
        doorAnimator.SetBool("locked", true);
        open = false;
    }
}
