using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject targetCollision;
    [SerializeField] private int sceneNo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetCollision)
        {
            SceneManager.LoadScene(sceneNo);
        }
    }
}
