using UnityEngine;

public class DisableObject : MonoBehaviour
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject objectToDisable;

    public void Disable()
    {
        objectToDisable.SetActive(false);
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
        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            MainPlayer mainPlayer = other.GetComponent<MainPlayer>();
            mainPlayer.playerIsInteracting = false;
            mainPlayer.HideCurrentPrompt();
            Disable();
        }
    }
}
