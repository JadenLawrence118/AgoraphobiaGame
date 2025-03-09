using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorZone : MonoBehaviour
{
    private bool canOpen;

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
        if (canOpen)
        {            
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.GetChild(0).GetComponent<OpenDoor>().Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PlayerCam")
        {
            canOpen = true;
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "PlayerCam")
        {
            canOpen = false;
            interactUI.SetActive(false);
        }
    }
}
