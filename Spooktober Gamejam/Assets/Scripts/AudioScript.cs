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
        mixerVolume = SettingsManager.instance.volume;
        //audioMixer.SetFloat("Volume", mixerVolume);
        //audioNum.text = (mixerVolume + 80).ToString();
    }
    //void Update()
    //{
        //mixerVolume = SettingsManager.instance.volume;
        //audioSlider.value = mixerVolume;
        //audioNum.text = (mixerVolume + 80).ToString();
    //}
    public void ChangeVolume()
    {
        mixerVolume = audioSlider.value;
        audioMixer.SetFloat("Volume", mixerVolume);
        audioNum.text = (mixerVolume + 80).ToString();
        SettingsManager.instance.volume = mixerVolume;
    }
}
