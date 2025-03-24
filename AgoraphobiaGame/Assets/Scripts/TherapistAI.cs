using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
public class TherapistAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private TherapistBehaviour behaviour;

    private GameObject player;

    public GameObject[] waypoints;
    public int waypointIndex;

    public bool move = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        behaviour = GetComponent<TherapistBehaviour>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!move)
        {
            behaviour.moving = false;
            Vector3 lookPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - transform.position;
            Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 2.0f);
        }
        else
        {
            behaviour.moving = true;
            agent.destination = waypoints[waypointIndex].transform.position;
        }
    }
}
