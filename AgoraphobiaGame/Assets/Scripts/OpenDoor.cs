using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool open = false;

    [SerializeField] private float moveSpeed = 1.0f;

    [Header("Rotations must be input as a positive float out of 360")]
    public int closedYRotation;
    public int openYRotation;


    void Update()
    {
        if (open)
        {
            Quaternion target = Quaternion.Euler(0, openYRotation, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, moveSpeed * Time.deltaTime);
        }
        else
        {
            Quaternion target = Quaternion.Euler(0, closedYRotation, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, moveSpeed * Time.deltaTime);
        }
    }

    public void Interact()
    {
        open = !open;
        gameObject.GetComponent<AudioSource>().Play();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.transform.parent.tag == "Player")
        {
            if (Input.GetAxisRaw("Interact") > 0)
            {
                Interact();
            }
        }
    }
}
