using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitch : MonoBehaviour
{
    [SerializeField] AudioClip transitionTo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<AudioSource>().enabled = false;
            other.gameObject.GetComponent<AudioSource>().clip = transitionTo;
            other.gameObject.GetComponent<AudioSource>().enabled = true;
        }
    }
}
