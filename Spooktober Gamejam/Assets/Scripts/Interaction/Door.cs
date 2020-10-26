using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private string openDoorPrompt;
    [SerializeField] private string closeDoorPrompt;
    [SerializeField] private bool keyRequired = false;
    [SerializeField] private GameObject linkedKey;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OpenDoor(Collider other) // don't judge me we need this
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            MainPlayer mainPlayer = other.GetComponent<MainPlayer>();
            if (animator.GetInteger("doorState") == -1 || animator.GetInteger("doorState") == 1)
            {
                mainPlayer.promptToDisplay = closeDoorPrompt;
                mainPlayer.ShowCurrentPrompt();
                animator.SetInteger("doorState", 0);
            }
            else
            {
                mainPlayer.promptToDisplay = openDoorPrompt;
                mainPlayer.ShowCurrentPrompt();
                animator.SetInteger("doorState", 1);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MainPlayer>())
        {
            if (animator.GetInteger("doorState") == -1 || animator.GetInteger("doorState") == 1)
            {
                other.GetComponent<MainPlayer>().promptToDisplay = openDoorPrompt;
            }
            else
            {
                other.GetComponent<MainPlayer>().promptToDisplay = closeDoorPrompt;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            other.GetComponent<MainPlayer>().playerIsInteracting = false;
            if (keyRequired && !linkedKey.activeInHierarchy)
            {
                OpenDoor(other);
            } else if (keyRequired && linkedKey.activeInHierarchy)
            {
                // TODO: play a nope sound and display some information in the ui that tells the player they need the key
                Debug.Log("This door is locked you need the key");
            } else
            {
                OpenDoor(other);
            }
        }
    }
}
