using UnityEngine;
using UnityEngine.Audio;

public static class SoundManager
{
    public static GameObject PlaySoundOneShot(GameObject objectToPlaySoundOn, AudioClip audioClip, AudioMixerGroup audioMixer, bool looping, float spatialBlend)
    {
        GameObject soundObject = new GameObject(objectToPlaySoundOn.name + " Sound");
        soundObject.AddComponent<AudioSource>();
        soundObject.transform.position = objectToPlaySoundOn.transform.position;
        soundObject.transform.rotation = objectToPlaySoundOn.transform.rotation;

        AudioSource audioSource = soundObject.GetComponent<AudioSource>();

        audioSource.outputAudioMixerGroup = audioMixer;
        audioSource.loop = looping;
        audioSource.spatialBlend = spatialBlend;

        audioSource.PlayOneShot(audioClip);
        return soundObject;
    }
}
