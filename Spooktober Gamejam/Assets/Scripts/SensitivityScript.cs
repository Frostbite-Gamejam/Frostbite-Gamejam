using CMF;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityScript : MonoBehaviour
{
    private float sensMultiplier = 0.5f;
    [SerializeField] private CameraMouseInput mouseInputScript;
    [SerializeField] private Slider sensSlider;
    [SerializeField] private Text sensNum;

    void Start()
    {
        mouseInputScript.mouseInputMultiplier = PlayerPrefs.GetFloat("savedSensnMultiplier", sensMultiplier);
        sensSlider.value = PlayerPrefs.GetFloat("savedSensMultiplier");
        sensNum.text = sensSlider.value.ToString("F2");
    }

    void Update()
    {
        sensSlider.value = PlayerPrefs.GetFloat("savedSensMultiplier");
        sensNum.text = sensSlider.value.ToString("F2");
    }

    public void ChangeSens()
    {
        PlayerPrefs.SetFloat("savedSensMultiplier", sensSlider.value);
        mouseInputScript.mouseInputMultiplier = PlayerPrefs.GetFloat("savedSensMultiplier");
        sensNum.text = sensSlider.value.ToString("F2");
    }
}
