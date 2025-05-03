using UnityEngine;

public class DollHeadMover : MonoBehaviour
{
    [SerializeField] private GameObject lightManager;
    private LightManager lightManagerScript;
    private bool playAnimation = false;
    private bool redLight = false;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightManagerScript = lightManager.GetComponent<LightManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!lightManagerScript.greenLight && !redLight)
        {
            redLight = true;
            animator.SetBool("turned", true);
        }
        if(lightManagerScript.greenLight &&  redLight)
        {
            redLight = false;
            animator.SetBool("turned", false);
        }
    }
}
