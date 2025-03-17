using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistBehaviour : MonoBehaviour
{
    public bool walking = false;

    private Animator animator;
    private Rigidbody rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity.x != 0 || rb.velocity.z != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}
