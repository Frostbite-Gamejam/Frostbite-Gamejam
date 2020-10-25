using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    #region DEFINTIONS
    [SerializeField] private float inputBufferTarget = 0f;
    [SerializeField] private LayerMask interactableLayer;

    public bool playerIsInteracting = false;
    private Camera playerCamera;
    private float inputBufferCounter = 0f;
    public KeyCode interactKey = KeyCode.E;
    private int viewHighlightDistance = 100;
    private bool objectHasBeenHighlighted = false;
    private HighlightEffect currentlyHighlightedItem = null;
    #endregion

    #region METHODS
    private void Awake()
    {
        playerCamera = Camera.main;
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
        if (Input.GetKey(interactKey) && inputBufferCounter >= inputBufferTarget)
        {
            playerIsInteracting = true;
        }
    }
    #endregion
    #region CUSTOMMETHODS
    private void InteractableRaycastHighlight()
    {
        if (Physics.Raycast(
            playerCamera.transform.position,
            playerCamera.transform.forward,
            out RaycastHit rayInfo,
            viewHighlightDistance,
            interactableLayer))
        {
            if (rayInfo.collider.isTrigger)
            {
                objectHasBeenHighlighted = true;
                currentlyHighlightedItem = rayInfo.collider.GetComponent<HighlightEffect>();
                rayInfo.collider.GetComponent<HighlightEffect>().SetOutlineStatus(true);
            }
                
        }
        else
        {
            objectHasBeenHighlighted = false;
            currentlyHighlightedItem = null;
            rayInfo.collider.GetComponent<HighlightEffect>().SetOutlineStatus(false);
        }
            
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * viewHighlightDistance, Color.red);
    }
    #endregion
}
