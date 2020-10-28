using CMF;
using System.Collections;
using System.Collections.Generic;
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
        sensMultiplier = SettingsManager.instance.sensivity;
        //mouseInputScript.mouseInputMultiplier = sensMultiplier;
        //sensNum.text = (sensMultiplier).ToString("F2");
    }
    //void Update()
    //{
        //sensMultiplier = SettingsManager.instance.sensivity;
        //sensSlider.value = sensMultiplier;
        //sensNum.text = (sensMultiplier).ToString("F2");
    //}
    public void ChangeSens()
    {
        sensMultiplier = sensSlider.value;
        mouseInputScript.mouseInputMultiplier = sensMultiplier;
        sensNum.text = (sensMultiplier).ToString("F2");
        SettingsManager.instance.sensivity = sensMultiplier;
    }
}
