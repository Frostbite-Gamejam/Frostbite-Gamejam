using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public bool playerIsInteracting = false;

    [SerializeField] private float inputBufferTarget = 0f;
    private float inputBufferCounter = 0f;

    public KeyCode interactKey = KeyCode.E;

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
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(interactKey) && inputBufferCounter >= inputBufferTarget)
        {
            playerIsInteracting = true;
        }
    }
}
