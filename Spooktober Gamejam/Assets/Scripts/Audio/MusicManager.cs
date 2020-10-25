using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] musicLibrary;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ChangeAudioTrack(musicLibrary[0]);    
    }

    private void ChangeAudioTrack(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
