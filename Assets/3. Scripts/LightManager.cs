using TMPro;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    //values
    [SerializeField] private GameObject player;
    [SerializeField] private float greenLightTime = 5.0f;
    [SerializeField] private float redLightTime = 2.0f;
    [SerializeField] private GameObject levelManager;


    //canvas references
    [SerializeField] private TMP_Text alert;

    //script variables
    [HideInInspector] public bool greenLight = true;
    private float time = 0;
    private Vector3 oldPos;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        time += Time.deltaTime;

        if(time >= greenLightTime - 3)
        {
            alert.text = ((int)(greenLightTime - time) + 1).ToString();
        }

        if(time >= greenLightTime && greenLight)
        {
            time = 0;
            greenLight = false;
            oldPos = player.transform.position;
            alert.text = "Stop";
        }

        if(time >= redLightTime && !greenLight)
        {
            time = 0;
            greenLight = true;
            alert.text = string.Empty;
            audioSource.Play();
        }

        if (!greenLight)
        {
            if (oldPos.z + 0.5f < player.transform.position.z)
            {
                alert.text = "Game Over";
                levelManager.GetComponent<LevelManager>().gameOver = true;
            }
        }
    }
}
