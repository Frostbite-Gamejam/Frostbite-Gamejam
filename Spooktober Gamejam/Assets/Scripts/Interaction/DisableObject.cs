using UnityEngine;

public class DisableObject : MonoBehaviour
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject objectToDisable;

    public void Disable()
    {
        objectToDisable.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>())
        {
            other.GetComponent<MainPlayer>().promptToDisplay = interactionPrompt;
        }

        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            other.GetComponent<MainPlayer>().playerIsInteracting = false;
            Disable();
        }
    }
}
