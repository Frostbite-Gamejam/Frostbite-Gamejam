using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public bool playerIsInteracting = false;

    public KeyCode interactKey = KeyCode.E;

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(interactKey))
        {
            playerIsInteracting = true;
        }
    }


}
