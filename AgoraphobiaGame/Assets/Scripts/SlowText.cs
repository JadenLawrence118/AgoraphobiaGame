using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlowText : MonoBehaviour
{
    [SerializeField] private TMP_Text NPCText;
    private string writer;
    private int textIndex = 0;
    private bool activated = false;

    [SerializeField] float typeSpeed = 0.04f;

    private void Start()
    {
        if (NPCText != null)
        {
            writer = NPCText.text;
            NPCText.text = "";
        }
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (activated)
        {
            activated = false;
            if (NPCText != null)
            {
                StartCoroutine(SlowType());
            }
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    IEnumerator SlowType()
    {
        if (writer.Length > 0)
        {
            NPCText.text = writer.Substring(0, textIndex);
            textIndex++;
        }
        if (NPCText.text.Length < writer.Length)
        {
            yield return new WaitForSeconds(typeSpeed);
            StartCoroutine(SlowType());
        }
    }

    public void TextChange(string newText)
    {
        StopAllCoroutines();
        transform.GetChild(0).gameObject.SetActive(true);
        writer = newText;
        NPCText.text = "";
        textIndex = 0;
        activated = true;
    }
}
