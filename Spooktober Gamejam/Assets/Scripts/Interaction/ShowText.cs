using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ShowText : MonoBehaviour {

    [SerializeField] private GameObject textBox;
    [SerializeField] private Text text;

    [SerializeField] private string interactionPrompt;
    [SerializeField] private string textBoxMsg;
    [SerializeField] private float waitTime;

    private bool isTextBoxActive = false;

    private void Start()
    {
        textBox.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MainPlayer>())
        {
            other.GetComponent<MainPlayer>().promptToDisplay = interactionPrompt;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>().playerIsInteracting && !isTextBoxActive)
        {
            MainPlayer mainPlayer = other.GetComponent<MainPlayer>();
            mainPlayer.HideCurrentPrompt();
            mainPlayer.playerIsInteracting = false;
            StartCoroutine(ShowTextBox(textBoxMsg));
        }
    }

    private IEnumerator ShowTextBox(string textContent) {
        text.text = textContent;
        textBox.SetActive(true);
        isTextBoxActive = true;
        yield return new WaitForSeconds(waitTime);
        textBox.SetActive(false);
        isTextBoxActive = false;
        StopCoroutine(ShowTextBox(textBoxMsg));
    }

    public void DisplayText(string textContent)
    {
        StartCoroutine(ShowTextBox(textBoxMsg));
    }
}
