using UnityEngine;

public class PlayerKeeper : MonoBehaviour
{
    private Vector3 positiondiff;
    private float yPos;
    private bool keyDown = false;

    private void OnCollisionEnter(Collision collision)
    {
        keyDown = false;
        positiondiff = transform.position - collision.transform.position;
        yPos = collision.transform.position.y;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (keyDown)
        {
            positiondiff = transform.position - collision.transform.position;
        }
        else
        {
            Vector3 newPos = transform.position - positiondiff;
            collision.transform.position = new Vector3(newPos.x, yPos, newPos.z);
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            keyDown = true;
        }
        else
        {
            keyDown = false;
        }
    }
}
