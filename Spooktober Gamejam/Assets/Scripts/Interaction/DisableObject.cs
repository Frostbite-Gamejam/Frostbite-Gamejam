using UnityEngine;

public class DisableObject : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private GameObject objectToDisable;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public void Disable()
    {
        objectToDisable.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>())
        {
            outline.enabled = true;
        }

        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            other.GetComponent<MainPlayer>().playerIsInteracting = false;
            Disable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        outline.enabled = false;
    }
}
