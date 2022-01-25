using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetValueSlider : MonoBehaviour
{
    public Slider slider;
    public Text ValorSliderText;

    float valorSlider;
    // Start is called before the first frame update
    void Start()
    {
        valorSlider = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        valorSlider = slider.value;
        ValorSliderText.text = valorSlider.ToString();
    }
}
