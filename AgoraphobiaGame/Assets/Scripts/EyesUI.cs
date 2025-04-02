using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class EyesUI : MonoBehaviour
{
    private static EyesUI self;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (self == null)
        {
            self = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
