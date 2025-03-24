using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TherapistBehaviour : MonoBehaviour
{
    public bool moving = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (moving)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    public void RotateLeft()
    {
        animator.SetFloat("TurnAngle", 1);
    }

    public void RotateRight()
    {
        animator.SetFloat("TurnAngle", -1);
    }
}
