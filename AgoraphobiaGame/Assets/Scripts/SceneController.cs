using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private Globals globals;

    [SerializeField] private bool realWorld = true;

    void Awake()
    {
        globals = GameObject.FindGameObjectWithTag("GameController").GetComponent<Globals>();

        if (realWorld)
        {
            globals.gameObject.GetComponent<CloseEyes>().MovePlayer(globals.realPos, globals.realRot, true);
        }
        else
        {
            globals.gameObject.GetComponent<CloseEyes>().MovePlayer(globals.imaginePos, globals.imagineRot, false);
        }
    }
}
