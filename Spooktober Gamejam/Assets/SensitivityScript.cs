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
        mouseInputScript.mouseInputMultiplier = sensMultiplier;
    }
    public void ChangeSens()
    {
        sensMultiplier = sensSlider.value;
        mouseInputScript.mouseInputMultiplier = sensMultiplier;
        sensNum.text = (sensMultiplier).ToString("F2");
    }
}
