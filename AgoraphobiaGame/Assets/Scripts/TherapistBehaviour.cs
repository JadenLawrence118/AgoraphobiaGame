using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TherapistBehaviour : MonoBehaviour
{
    public bool move = false;

    private PlayableDirector director;
    private Animator animator;

    public TimelineAsset[] timelineAssets;

    void Start()
    {
        animator = GetComponent<Animator>();
        director = GetComponent<PlayableDirector>();
    }

    void Update()
    {
        // debug
        if (move)
        {
            move = false;
            director.Play();
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

    public void StartWalk()
    {
        animator.SetBool("Moving", true);
    }
    public void EndWalk()
    {
        animator.SetBool("Moving", false);
    }
}
