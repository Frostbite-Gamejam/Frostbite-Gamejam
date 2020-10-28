using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ShowText : MonoBehaviour 
{

    private MainPlayer mainPlayer;

    [SerializeField] private GameObject textBox;
    [SerializeField] private Text text;

    [SerializeField] private string interactionPrompt;
    [SerializeField] private string textBoxMsg;
    [SerializeField] private float waitTime;

    public bool isTextBoxActive = false;
    private bool playerIsInTrigger;

    private void Awake()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
    }

    private void Start()
    {
        textBox.SetActive(false);
    }

    private void Update()
    {
        if (mainPlayer.playerIsInteracting && playerIsInTrigger)
        {
            mainPlayer.HideCurrentPrompt();
            StartCoroutine(ShowTextBox(textBoxMsg));
        }
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
        if (other.GetComponent<MainPlayer>() && !isTextBoxActive)
        {
            playerIsInTrigger = true;
        } else
        {
            playerIsInTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<MainPlayer>())
        {
            playerIsInTrigger = false;
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
