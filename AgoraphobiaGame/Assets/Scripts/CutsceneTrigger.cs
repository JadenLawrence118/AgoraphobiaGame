using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] int assetIndex;

    [SerializeField] private bool onlyOnce = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (onlyOnce)
            {
                GetComponent<BoxCollider>().enabled = false;
            }
            director.Play();
        }
    }
}
