using UnityEngine;

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
