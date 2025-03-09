using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Globals : MonoBehaviour
{
    private static Globals self;

    public bool realWorld = true;

    public Vector3 realPos;
    public Vector3 realRot;
    public Vector3 imaginePos;
    public Vector3 imagineRot;

    public GameObject eyesUI;
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

        eyesUI = GameObject.Find("EyesUI");


        realPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
