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
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("savedVolume", mixerVolume));
        audioNum.text = (mixerVolume + 80).ToString();
    }
    
    void Update()
    {
        audioSlider.value = PlayerPrefs.GetFloat("savedVolume");
        audioNum.text = (mixerVolume + 80).ToString();
    }

    public void ChangeVolume()
    {
        PlayerPrefs.SetFloat("savedVolume", audioSlider.value);
        mixerVolume = PlayerPrefs.GetFloat("savedVolume");
        audioMixer.SetFloat("Volume", mixerVolume);
        audioNum.text = (mixerVolume + 80).ToString();
    }
}
