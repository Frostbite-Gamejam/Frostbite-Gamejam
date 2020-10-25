using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private bool keyRequired = false;
    [SerializeField] private GameObject linkedKey;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void ToggleDoor()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            if (animator.GetInteger("doorState") == -1 || animator.GetInteger("doorState") == 1)
                animator.SetInteger("doorState", 0);
            else
                animator.SetInteger("doorState", 1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            other.GetComponent<MainPlayer>().playerIsInteracting = false;
            if (keyRequired && !linkedKey.activeInHierarchy) 
                ToggleDoor();
            else if (keyRequired && linkedKey.activeInHierarchy) 
                Debug.Log("This door is locked you need the key");
            else 
                ToggleDoor();
        }
    }
}
