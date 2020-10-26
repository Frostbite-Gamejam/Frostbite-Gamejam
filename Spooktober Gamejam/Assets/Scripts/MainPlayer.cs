using UnityEngine;
using UnityEngine.Audio;

public class MainPlayer : MonoBehaviour
{
    #region DEFINTIONS
    [SerializeField] private AudioMixer audioMixer;
    private HighlightEffect currentlyHighlightedItem = null;
    private Camera playerCamera;
    private InteractionPrompt interactionPrompt;

    [SerializeField] private float viewHighlightDistance = 100;
    [SerializeField] private float inputBufferTarget = 0f;
    [SerializeField] private LayerMask interactableLayer;

    [HideInInspector] public bool playerIsInteracting = false;
    [HideInInspector] public bool canInteract = true;
    [HideInInspector] public string promptToDisplay;

    public KeyCode interactKey = KeyCode.E;

    private float mixerVolume = -35f;
    private float inputBufferCounter = 0f;
    private bool objectHasBeenHighlighted = false;
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
        audioMixer.SetFloat("Volume", mixerVolume);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftBracket))
        {
            mixerVolume = mixerVolume - 0.5f;
            ChangeVolume(mixerVolume);
        } else if (Input.GetKey(KeyCode.RightBracket))
        {
            mixerVolume = mixerVolume + 0.5f;
            ChangeVolume(mixerVolume);
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (IsInLayerMask(other.gameObject.layer, interactableLayer))
        {
            interactionPrompt.ShowPromptBox(promptToDisplay);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(interactKey) && inputBufferCounter >= inputBufferTarget && canInteract)
        {
            playerIsInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsInLayerMask(other.gameObject.layer, interactableLayer))
        {
            interactionPrompt.HidePromptBox();
        }
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

    private void ChangeVolume(float value)
    {
        audioMixer.SetFloat("Volume", value);
    }

    public void HideCurrentPrompt()
    {
        interactionPrompt.HidePromptBox();
    }

    public void UpdateCurrentPrompt(string message)
    {
        interactionPrompt.ShowPromptBox(message);
    }
    #endregion
}
