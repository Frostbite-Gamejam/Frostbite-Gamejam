using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR;

public class MainPlayer : MonoBehaviour
{
    #region DEFINTIONS
    private InteractionPrompt interactionPrompt;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private LayerMask interactableLayer;
    [HideInInspector] public bool canInteract = true;
    [HideInInspector] public bool playerIsInteracting = false;
    [HideInInspector] public string promptToDisplay;
    public KeyCode interactKey = KeyCode.E;
    private float mixerVolume = -35f;
    #endregion

    #region METHODS
    private void Awake()
    {
        interactionPrompt = GetComponent<InteractionPrompt>();
    }
    private void Start()
    {
        audioMixer.SetFloat("Volume", mixerVolume);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            playerIsInteracting = true;
        } else
        {
            playerIsInteracting = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            mixerVolume = mixerVolume - 0.5f;
            ChangeVolume(mixerVolume);
        } else if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            mixerVolume = mixerVolume + 0.5f;
            ChangeVolume(mixerVolume);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsInLayerMask(other.gameObject.layer, interactableLayer))
        {
            interactionPrompt.ShowPromptBox(promptToDisplay);
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
