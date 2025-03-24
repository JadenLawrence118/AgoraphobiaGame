using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaypoint : MonoBehaviour
{
    private TherapistBehaviour behaviour;
    void Start()
    {
        behaviour = GameObject.Find("Therapist").GetComponent<TherapistBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == behaviour.gameObject)
        {
            behaviour.gameObject.GetComponent<TherapistAI>().move = false;
        }
    }
}
