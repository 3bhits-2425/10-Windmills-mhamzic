using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Windmills : MonoBehaviour
{

    [SerializeField] private Light lamp;
    [SerializeField] private Slider slider;

    void Start()
    {
        lamp.intensity = 0; 
        
    }
    void Update()
    {
       lamp.intensity = slider.value;
    }
}
