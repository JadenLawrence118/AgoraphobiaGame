using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TherapistBehaviour : MonoBehaviour
{
    private float lastXPos;
    private float lastZPos;
    private float lastRot;

    public bool moving = false;

    private PlayableDirector director;
    public bool move = false;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        director = GetComponent<PlayableDirector>();
    }

    void Update()
    {
        // checks current position against previous position to see if moving
        if (moving)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        // get last position
        lastXPos = transform.position.x;
        lastZPos = transform.position.z;


        // debug
        if (move)
        {
            move = false;
            director.Play();
        }
    }

    public void RotateLeft()
    {
        animator.SetFloat("TurnAngle", -1);
    }

    public void RotateRight()
    {
        animator.SetFloat("TurnAngle", 1);
    }
}
