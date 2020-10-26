using UnityEngine.Audio;
using UnityEngine;

public static class SoundManager
{
    public static GameObject PlaySoundOneShot(GameObject objectToPlaySoundOn, AudioClip audioClip, AudioMixerGroup audioMixer, bool looping, bool stackableSound, float spatialBlend)
    {
        if (!stackableSound && objectToPlaySoundOn.GetComponentInChildren<AudioSource>())
        {
            return null;
        }

        GameObject soundObject = new GameObject(objectToPlaySoundOn.name + " Sound");
        soundObject.AddComponent<AudioSource>();
        soundObject.transform.position = objectToPlaySoundOn.transform.position;
        soundObject.transform.rotation = objectToPlaySoundOn.transform.rotation;

        soundObject.transform.parent = objectToPlaySoundOn.transform;

        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = audioMixer;
        audioSource.loop = looping;
        audioSource.spatialBlend = spatialBlend;

        audioSource.Play();
        return soundObject;
    }
}
