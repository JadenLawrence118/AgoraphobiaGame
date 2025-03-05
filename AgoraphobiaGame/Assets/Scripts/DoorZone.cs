using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorZone : MonoBehaviour
{
    private float lastPress;

    public GameObject interactUI;

    private void Awake()
    {
        interactUI = GameObject.Find("InteractMessage");
    }
    private void Start()
    {
        interactUI.SetActive(false);
    }
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
                transform.GetChild(0).GetComponent<OpenDoor>().Interact();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PlayerCam")
        {
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "PlayerCam")
        {
            interactUI.SetActive(false);
        }
    }
}
