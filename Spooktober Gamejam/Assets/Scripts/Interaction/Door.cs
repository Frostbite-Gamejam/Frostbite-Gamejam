using UnityEngine;
using UnityEngine.Audio;

public class Door : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private AudioMixerGroup mainMixer;
    [SerializeField] private AudioClip doorLockedSound;
    [SerializeField] private AudioClip doorSwingSound;
    [SerializeField] private string lockedDoorMessage;
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
            {
                animator.SetInteger("doorState", 0);
                Destroy(SoundManager.PlaySoundOneShot(gameObject, doorSwingSound, mainMixer, false, false, 0f), doorLockedSound.length);
            }
            else
            {
                animator.SetInteger("doorState", 1);
                Destroy(SoundManager.PlaySoundOneShot(gameObject, doorSwingSound, mainMixer, false, false, 0f), doorLockedSound.length);
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
                ToggleDoor();
            } else if (keyRequired && linkedKey.activeInHierarchy)
            {
                Destroy(SoundManager.PlaySoundOneShot(gameObject, doorLockedSound, mainMixer, false, false, 0f), doorLockedSound.length);
            } else
            {
                ToggleDoor();
            }
        }
    }
}
