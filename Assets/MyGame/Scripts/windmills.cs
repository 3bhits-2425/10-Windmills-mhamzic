using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Windmills : MonoBehaviour
{
    [SerializeField] private Light lamp;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshPro rgb;
    [SerializeField] private Button[] buttons;

    void Start()
    {
        lamp.intensity = 0;
        buttons[1].interactable = false;
        buttons[2].interactable = false;

        buttons[0].onClick.AddListener(() => buttons[1].interactable = true);
        buttons[1].onClick.AddListener(() => buttons[2].interactable = true);
    }

    void Update()
    {
        lamp.intensity = slider.value;
        rgb.text = lamp.intensity.ToString("F2");
    }
}
