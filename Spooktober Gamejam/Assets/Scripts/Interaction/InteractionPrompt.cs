using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPrompt : MonoBehaviour
{
    private GameObject promptBox;
    private Text promptBoxText;
    private bool promptShowing;

    private void Awake()
    {
        promptBox = GameObject.FindGameObjectWithTag("PromptBox");
        promptBoxText = GameObject.FindGameObjectWithTag("PromptBoxText").GetComponent<Text>();
        promptShowing = false;
    }

    private void Start()
    {
        promptBox.SetActive(false);
    }

    public void showPromptBox(string message)
    {
        promptBoxText.text = message;
        promptBox.SetActive(true);
        promptShowing = true;
    }

    public void hidePromptBox()
    {
        if (promptShowing)
        {
            promptBoxText.text = "";
            promptBox.SetActive(false);
            promptShowing = false;
        }
    }
}
