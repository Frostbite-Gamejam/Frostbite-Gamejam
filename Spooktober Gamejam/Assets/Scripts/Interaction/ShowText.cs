using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowText : MonoBehaviour

{
    [SerializeField] private GameObject textBox;
    [SerializeField] private Text text;
    [SerializeField] private string textBoxMsg;
    [SerializeField] private float waitTime;
    private bool isTextBoxActive = false;

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
