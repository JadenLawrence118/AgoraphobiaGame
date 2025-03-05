using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorZone : MonoBehaviour
{
    private float lastPress;
    private void Update()
    {
        lastPress = Input.GetAxisRaw("Interact");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "PlayerCam")
        {
            if (Input.GetAxisRaw("Interact") < lastPress)
            {
                print(other.name);
                transform.GetChild(0).GetComponent<OpenDoor>().Interact();
            }
        }
    }
}
