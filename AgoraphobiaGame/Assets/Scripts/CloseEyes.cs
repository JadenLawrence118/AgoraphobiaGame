using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseEyes : MonoBehaviour
{
    private Globals globals;

    private void Awake()
    {
        globals = GetComponent<Globals>();
    }
    public void Eyes()
    {
        globals.eyesUI.SetActive(true);
        globals.eyesUI.GetComponent<PlayableDirector>().Play();
    }

    public void MovePlayer(Vector3 newPos, Vector3 newRot, bool realWorld)
    {
        GameObject.FindGameObjectWithTag("Player").transform.localPosition = newPos;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCam>().yaw = newRot.y;
        globals.realWorld = realWorld;
    }

    public void ChangeScene()
    {
        if (globals.realWorld)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
