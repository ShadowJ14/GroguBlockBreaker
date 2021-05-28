using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueToText : MonoBehaviour
{
    public Slider sliderUI;
    private TextMeshProUGUI textSliderValue;

    void Start()
    {
        textSliderValue = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        string sliderMessage = sliderUI.value.ToString();
        textSliderValue.text = sliderMessage;
    }
}
