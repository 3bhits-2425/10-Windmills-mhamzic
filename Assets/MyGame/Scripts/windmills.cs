using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Windmills : MonoBehaviour
{

    [SerializeField] private Light lamp;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshPro rgb;
 

    void Start()
    {
        lamp.intensity = 0;
    }
    void Update()
    {
        lamp.intensity = slider.value;
        rgb.text = lamp.intensity.ToString();
    }
}
