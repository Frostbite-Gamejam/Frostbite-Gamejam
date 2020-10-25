using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ShowText : MonoBehaviour {

    private GameObject textBox;
    private Text text;

    [SerializeField] private string textBoxMsg;
    [SerializeField] private float waitTime;

    private bool isTextBoxActive = false;

    private void Awake()
    {
        textBox = GameObject.FindGameObjectWithTag("Textbox");
        text = GameObject.FindGameObjectWithTag("Textboxtext").GetComponent<Text>();
    }

    private void Start()
    {
        textBox.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>().playerIsInteracting && !isTextBoxActive)
        {
            other.GetComponent<MainPlayer>().playerIsInteracting = false;
            StartCoroutine(ShowTextBox());
        }
    }

    private IEnumerator ShowTextBox() {
        text.text = textBoxMsg;
        textBox.SetActive(true);
        isTextBoxActive = true;
        yield return new WaitForSeconds(waitTime);
        textBox.SetActive(false);
        isTextBoxActive = false;
        StopCoroutine(ShowTextBox());
    }
}
