using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseEyes : MonoBehaviour
{
    private Globals globals;
    private void Awake()
    {
        globals = GetComponent<Globals>();
    }
    public void Eyes()
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

    IEnumerator WaitForSceneLoad(Vector3 newPos, Vector3 newRot, bool realWorld)
    {
        yield return new WaitForSecondsRealtime(1f);
        GameObject.FindGameObjectWithTag("Player").transform.position = newPos;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCam>().yaw = newRot.y;
        globals.realWorld = realWorld;
    }
}
