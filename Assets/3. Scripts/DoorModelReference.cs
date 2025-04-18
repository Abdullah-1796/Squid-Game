using UnityEngine;

public class DoorModelReference : MonoBehaviour
{
    [SerializeField] private GameObject doorModel;
    private Animator animator;

    void Start()
    {
        animator = doorModel.GetComponent<Animator>();
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
