using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private float mixerVolume = 0f;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider audioSlider;
    [SerializeField] private Text audioNum;
    void Start()
    {
        audioMixer.SetFloat("Volume", mixerVolume);
    }
    public void ChangeVolume()
    {
        mixerVolume = audioSlider.value;
        audioMixer.SetFloat("Volume", mixerVolume);
        audioNum.text = (mixerVolume + 80).ToString();
    }
}
