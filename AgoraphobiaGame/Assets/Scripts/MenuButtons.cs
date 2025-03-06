using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Color32 hoverColour;
    [SerializeField] private Color32 startColour;
    public void Play()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadInstr()
    {
        SceneManager.LoadScene(4);
    }
    public void BackHome()
    {
        Destroy(GameObject.FindGameObjectWithTag("GameController"));
        SceneManager.LoadScene(3);
    }
    public void colourChange()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = hoverColour;
    }
    public void colourRevert()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = startColour;
    }
}
