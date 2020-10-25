using UnityEngine;

[RequireComponent(typeof(Outline))]
public class HighlightEffect : MonoBehaviour
{
    private Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>())
        {
            outline.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        outline.enabled = false;
    }
}
