using TMPro;
using UnityEngine;

public class InteractionPrompt : MonoBehaviour
{
    [SerializeField] private GameObject promptBox;
    [SerializeField] private TextMeshProUGUI promptBoxText;
    private bool promptShowing;

    private void Start()
    {
        promptShowing = false;
        promptBox.SetActive(false);
    }

    public void ShowPromptBox(string message)
    {
        promptBoxText.text = message;
        promptBox.SetActive(true);
        promptShowing = true;
    }

    public void HidePromptBox()
    {
        if (promptShowing)
        {
            promptBoxText.text = "";
            promptBox.SetActive(false);
            promptShowing = false;
        }
    }
}
