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
        SceneManager.LoadScene(3);
    }
    public void LoadInstr()
    {
        SceneManager.LoadScene(2);
    }
    public void BackHome()
    {
        Destroy(GameObject.FindGameObjectWithTag("GameController"));
        SceneManager.LoadScene(1);
    }
    public void colourChange()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = hoverColour;
    }
    public void colourRevert()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = startColour;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
