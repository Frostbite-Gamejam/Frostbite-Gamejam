<<<<<<< HEAD
﻿using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    #region DEFINITIONS
    public GameObject inventoryItem = null;
    public bool playerIsInteracting = false;
    private float inputBufferCounter = 0f;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode accessingNotebook = KeyCode.N;

    [SerializeField] private float inputBufferTarget = 0f;
    #endregion

    #region METHODS
    private void Start()
    {
        inputBufferCounter = inputBufferTarget;
    }

    private void FixedUpdate()
    {
        inputBufferCounter = inputBufferCounter + 1 * Time.deltaTime;
        if (playerIsInteracting)
            inputBufferCounter = 0f;
        if (Input.GetKey(accessingNotebook) && inputBufferCounter >= inputBufferTarget)
            Debug.Log(inventoryItem.GetComponent<NotebookHandler>().notebookContents);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(interactKey) && inputBufferCounter >= inputBufferTarget)
        {
            Debug.Log($"Player is interacting");
            playerIsInteracting = true;
        }
        else
            Debug.Log($"No interactions are taking place");
    }
    #endregion
}
=======
﻿using UnityEngine;

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
    #endregion

    #region METHODS
    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
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
    #endregion
}
>>>>>>> objectHighlighting-Fix
