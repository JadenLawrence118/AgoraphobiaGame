using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagineUI : MonoBehaviour
{
    [SerializeField] private GameObject openPanel;
    [SerializeField] private GameObject closedPanel;
    private bool open = true;
    void Start()
    {
        openPanel.SetActive(open);
        closedPanel.SetActive(!open);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            open = !open;
            openPanel.SetActive(open);
            closedPanel.SetActive(!open);
        }
    }
}
