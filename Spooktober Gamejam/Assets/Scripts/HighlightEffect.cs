using UnityEngine;

[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(BoxCollider))]
public class HighlightEffect : MonoBehaviour
{
    #region DEFINITIONS
    private Outline outline;
    private BoxCollider boxCollider;
    #endregion

    #region METHODS
    private void Awake()
    {
        outline = GetComponent<Outline>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        outline.enabled = false;
        if (!boxCollider.isTrigger)
        {
            Debug.LogError("The box collider component needs to be a trigger in order for this script to function properly");
        }
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
    #endregion
    #region CUSTOMMETHODS
    public void SetOutlineStatus(bool status) => outline.enabled = status;
    #endregion
}
