using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    #region DEFINTIONS
    [SerializeField] private float viewHighlightDistance = 100;
    [SerializeField] private float inputBufferTarget = 0f;
    [SerializeField] private LayerMask interactableLayer;

    public KeyCode interactKey = KeyCode.E;
    public bool playerIsInteracting = false;

    private Camera playerCamera;
    private float inputBufferCounter = 0f;
    private bool objectHasBeenHighlighted = false;
    private HighlightEffect currentlyHighlightedItem = null;
    private InteractionPrompt interactionPrompt;
    #endregion

    #region METHODS
    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        interactionPrompt = GetComponent<InteractionPrompt>();
    }
    private void Start()
    {
        inputBufferCounter = inputBufferTarget;
    }

    private void FixedUpdate()
    {
        inputBufferCounter = inputBufferCounter + 1 * Time.deltaTime;
        if (playerIsInteracting)
        {
            inputBufferCounter = 0f;
        }
        InteractableRaycastHighlight();
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsInLayerMask(other.gameObject.layer, interactableLayer)) // if 'other' is on the interactable layer
        {
            interactionPrompt.showPromptBox();
        }

        if (Input.GetKey(interactKey) && inputBufferCounter >= inputBufferTarget)
        {
            playerIsInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactionPrompt.hidePromptBox();
    }
    #endregion
    #region CUSTOMMETHODS
    private void InteractableRaycastHighlight()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit rayInfo, viewHighlightDistance, interactableLayer))
        {
            if (rayInfo.collider.isTrigger)
            {
                currentlyHighlightedItem = rayInfo.collider.GetComponent<HighlightEffect>();
                objectHasBeenHighlighted = true;
                rayInfo.collider.GetComponent<HighlightEffect>().SetOutlineStatus(true);
            }
        }
        else
        {
            if (objectHasBeenHighlighted)
            {
                currentlyHighlightedItem.SetOutlineStatus(false);
            }
        }

        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * viewHighlightDistance, Color.red);
    }

    private bool IsInLayerMask(int layer, LayerMask layermask)
    {
        return layermask == (layermask | (1 << layer));
    }
    #endregion
}
