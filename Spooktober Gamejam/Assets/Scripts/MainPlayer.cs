using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR;

public class MainPlayer : MonoBehaviour
{
    #region DEFINTIONS
    private InteractionPrompt interactionPrompt;
    [SerializeField] private LayerMask interactableLayer;
    [HideInInspector] public bool canInteract = true;
    [HideInInspector] public bool playerIsInteracting = false;
    [HideInInspector] public string promptToDisplay;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private KeyCode pauseKey;
    #endregion

    #region METHODS
    private void Awake()
    {
        interactionPrompt = GetComponent<InteractionPrompt>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && canInteract)
        {
            playerIsInteracting = true;
        } 
        else
        {
            playerIsInteracting = false;
        }

        if (Input.GetKeyDown(pauseKey) && canInteract)
        {

        }
        else
        {

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
