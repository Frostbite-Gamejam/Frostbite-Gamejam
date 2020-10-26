using UnityEngine;
using UnityEngine.Audio;

public class MainPlayer : MonoBehaviour
{
    #region DEFINTIONS
    [SerializeField] private AudioMixer audioMixer;
    private HighlightEffect currentlyHighlightedItem = null;
    private Camera playerCamera;

    [SerializeField] private float viewHighlightDistance = 100;
    [SerializeField] private float inputBufferTarget = 0f;
    [SerializeField] private LayerMask interactableLayer;
    [HideInInspector] public bool playerIsInteracting = false;
    [HideInInspector] public bool canInteract = true;

    public KeyCode interactKey = KeyCode.E;

    private float mixerVolume = -35f;
    private float inputBufferCounter = 0f;
    private bool objectHasBeenHighlighted = false;
    #endregion

    #region METHODS
    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
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

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(interactKey) && inputBufferCounter >= inputBufferTarget && canInteract)
        {
            playerIsInteracting = true;
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

    private void ChangeVolume(float value)
    {
        audioMixer.SetFloat("Volume", value);
    }
    #endregion
}
