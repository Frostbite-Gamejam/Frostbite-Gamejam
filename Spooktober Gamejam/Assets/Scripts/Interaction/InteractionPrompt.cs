using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPrompt : MonoBehaviour
{

    private GameObject promptBox;
    private Text text;
    private bool promptShowing;

    private void Awake()
    {
        promptBox = GameObject.FindGameObjectWithTag("PromptBox");
        text = promptBox.GetComponent<Text>();
        promptShowing = false;
    }

    private void Start()
    {
        promptBox.SetActive(false);
        text.text = "Press E to interact"; // TODO handle custom controls, ie "Press <interact key> to interact" not "Press E to interact"
    }

    public void showPromptBox()
    {
        promptShowing = true;
        promptBox.SetActive(true);
    }

    public void hidePromptBox()
    {
        if (promptShowing)
        {
            promptBox.SetActive(false);
        }
    }
}
