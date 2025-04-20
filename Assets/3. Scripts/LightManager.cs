using TMPro;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    //values
    [SerializeField] private GameObject player;
    [SerializeField] private float greenLightTime = 5.0f;
    [SerializeField] private float redLightTime = 2.0f;

    //canvas references
    [SerializeField] private TMP_Text alert;

    //script variables
    private bool greenLight = true;
    private float time = 0;
    private Vector3 oldPos;

    
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
        }
    }

    private void LateUpdate()
    {
        if(!greenLight)
        {
            if(oldPos != player.transform.position)
            {
                alert.text = "Game Over";
                Time.timeScale = 0;
            }
        }
    }
}
