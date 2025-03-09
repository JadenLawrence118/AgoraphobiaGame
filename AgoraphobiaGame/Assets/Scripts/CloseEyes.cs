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

    IEnumerator WaitForSceneLoad(Vector3 newPos, Vector3 newRot, bool realWorld)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        GameObject.FindGameObjectWithTag("Player").transform.position = newPos;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCam>().yaw = newRot.y;
        globals.realWorld = realWorld;
    }

    public void ChangeScene()
    {
        if (globals.realWorld)
        {
            SceneManager.LoadScene(1);
            StartCoroutine(WaitForSceneLoad(globals.imaginePos, globals.imagineRot, false));
        }
        else
        {
            SceneManager.LoadScene(0);
            StartCoroutine(WaitForSceneLoad(globals.realPos, globals.realRot, true));
        }
    }
}
