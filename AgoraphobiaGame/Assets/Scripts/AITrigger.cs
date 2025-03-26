using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AITrigger : MonoBehaviour
{
    [SerializeField] int waypointIndex;

    [SerializeField] private bool onlyOnce = true;

    [SerializeField] private SlowText NPCText;
    private GameObject textPanel;

    [SerializeField] private string newText;

    private TherapistAI therapist;

    private void Awake()
    {
        therapist = GameObject.Find("Therapist").GetComponent<TherapistAI>();;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // disables this trigger after being activated if the bool is true
            if (onlyOnce)
            {
                GetComponent<BoxCollider>().enabled = false;
            }

            // checks if NPC is already where we're telling it to go before sending it there
            if (therapist.waypointIndex != waypointIndex)
            {
                therapist.waypointIndex = waypointIndex;
                therapist.move = true;
            }

            // sets the UI NPC text and displays it on screen
            if (NPCText != null)
            {
                NPCText.TextChange(newText);
            }
        }
    }
}
