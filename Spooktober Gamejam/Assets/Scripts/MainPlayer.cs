﻿using UnityEngine;
using UnityEngine.Audio;

public class MainPlayer : MonoBehaviour
{
    #region DEFINTIONS
    [SerializeField] private AudioMixer audioMixer;
    private HighlightEffect currentlyHighlightedItem = null;
    private Camera playerCamera;

    [SerializeField] private float viewHighlightDistance = 100;
    [SerializeField] private LayerMask interactableLayer;

    public KeyCode interactKey = KeyCode.E;
    public bool playerIsInteracting = false;

    private Camera playerCamera;
    private float inputBufferTarget = 0.1f;
    private float inputBufferCounter = 0f;
    private bool objectHasBeenHighlighted = false;
    private HighlightEffect currentlyHighlightedItem = null;
    private InteractionPrompt interactionPrompt;
    public string promptToDisplay;
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
        if (IsInLayerMask(other.gameObject.layer, interactableLayer)) // if 'other' is on the interactable layer
        {
            interactionPrompt.showPromptBox(promptToDisplay);
        }
    }

    private void OnTriggerStay(Collider other)
    {
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

    public void HideCurrentPrompt()
    {
        interactionPrompt.hidePromptBox();
    }

    public void ShowCurrentPrompt()
    {
        interactionPrompt.showPromptBox(promptToDisplay);
    }
    
    private void ChangeVolume(float value)
    {
        audioMixer.SetFloat("Volume", value);
    }
    #endregion
}
