using UnityEngine;
using UnityEngine.Audio;

public class Door : MonoBehaviour
{
    private Animator animator;
    private MainPlayer mainPlayer;
    [SerializeField] private AudioMixerGroup mainMixer;
    [SerializeField] private AudioClip doorLockedSound;
    [SerializeField] private AudioClip doorSwingSound;
    [SerializeField] private bool keyRequired = false;
    [SerializeField] private GameObject linkedKey;

    private string interactionPrompt = "Hit E To Open Door";
    private bool playerIsInTrigger = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
    }

    private void Update()
    {
        if (mainPlayer.playerIsInteracting && playerIsInTrigger)
        {
            if (keyRequired && !linkedKey.activeInHierarchy)
            {
                ToggleDoor();
            }
            else if (keyRequired && linkedKey.activeInHierarchy)
            {
                Destroy(SoundManager.PlaySoundOneShot(gameObject, doorLockedSound, mainMixer, false, true, 0f), doorLockedSound.length);
            }
            else
            {
                ToggleDoor();
            }
        }
    }

    private void ToggleDoor()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            if (animator.GetInteger("doorState") == -1 || animator.GetInteger("doorState") == 1)
            {
                interactionPrompt = "Hit E To Close Door";
                mainPlayer.UpdateCurrentPrompt(interactionPrompt);
                animator.SetInteger("doorState", 0);
                Destroy(SoundManager.PlaySoundOneShot(gameObject, doorSwingSound, mainMixer, false, true, 0f), doorLockedSound.length);
            }
            else
            {
                interactionPrompt = "Hit E To Open Door";
                mainPlayer.GetComponent<MainPlayer>().UpdateCurrentPrompt(interactionPrompt);
                animator.SetInteger("doorState", 1);
                Destroy(SoundManager.PlaySoundOneShot(gameObject, doorSwingSound, mainMixer, false, true, 0f), doorLockedSound.length);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MainPlayer>())
        {
            other.GetComponent<MainPlayer>().promptToDisplay = interactionPrompt;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<MainPlayer>())
        {
            playerIsInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<MainPlayer>())
        {
            playerIsInTrigger = false;
        }
    }
}
