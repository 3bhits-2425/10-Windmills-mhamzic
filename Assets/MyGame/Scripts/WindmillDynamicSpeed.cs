using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindmillGameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] windmills;
    [SerializeField] private Slider[] windmillSliders;
    [SerializeField] private Button lockButton;
    [SerializeField] private Button applyColorButton;
    [SerializeField] private GameObject colorTarget;
    private int currentWindmillIndex = 0;
    private float[] windmillSpeeds = new float[3];
    private bool[] isLocked = new bool[3];
    private bool allLocked = false;
    private float maxRotationSpeed = 255f;
    private float decreaseRate = 100f;

    [SerializeField] private Light lamp;
    [SerializeField] private Slider lampSlider;
    [SerializeField] private TextMeshPro rgb;
    [SerializeField] private Button[] buttons;

    private void Start()
    {
        lockButton.onClick.AddListener(LockCurrentWindmill);
        applyColorButton.onClick.AddListener(ApplyColor);

        lamp.intensity = 0;
        buttons[1].interactable = false;
        buttons[2].interactable = false;

        buttons[0].onClick.AddListener(() => buttons[1].interactable = true);
        buttons[1].onClick.AddListener(() => buttons[2].interactable = true);
    }

    private void Update()
    {
        if (currentWindmillIndex < windmills.Length)
        {
            if (!isLocked[currentWindmillIndex])
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    IncreaseWindmillValue(Time.deltaTime);
                }
                else
                {
                    DecreaseWindmillValue(Time.deltaTime);
                }
            }
        }
        RotateWindmills();

        lamp.intensity = lampSlider.value;
        rgb.text = lamp.intensity.ToString("F2");
    }

    private void IncreaseWindmillValue(float deltaTime)
    {
        if (currentWindmillIndex < windmills.Length && !isLocked[currentWindmillIndex])
        {
            float newValue = Mathf.Clamp(windmillSpeeds[currentWindmillIndex] + (deltaTime * 100f), 0, maxRotationSpeed);
            windmillSpeeds[currentWindmillIndex] = newValue;
            windmillSliders[currentWindmillIndex].value = newValue;
        }
    }

    private void DecreaseWindmillValue(float deltaTime)
    {
        if (currentWindmillIndex < windmills.Length && !isLocked[currentWindmillIndex])
        {
            float newValue = Mathf.Clamp(windmillSpeeds[currentWindmillIndex] - (deltaTime * decreaseRate), 0, maxRotationSpeed);
            windmillSpeeds[currentWindmillIndex] = newValue;
            windmillSliders[currentWindmillIndex].value = newValue;
        }
    }

    private void RotateWindmills()
    {
        for (int i = 0; i < windmills.Length; i++)
        {
            if (i == currentWindmillIndex && isLocked[i])
            {
                float speed = windmillSpeeds[i];
                windmills[i].transform.Rotate(0, 0, speed * Time.deltaTime);
            }
        }
    }

    public void LockCurrentWindmill()
    {
        if (currentWindmillIndex < windmills.Length && !isLocked[currentWindmillIndex])
        {
            isLocked[currentWindmillIndex] = true;
            if (currentWindmillIndex < windmills.Length - 1)
            {
                currentWindmillIndex++;
                windmillSliders[currentWindmillIndex].interactable = true;
            }
            else
            {
                allLocked = true;
            }
        }
    }

    public void ApplyColor()
    {
        if (allLocked)
        {
            Color newColor = new Color(windmillSpeeds[0] / 255f, windmillSpeeds[1] / 255f, windmillSpeeds[2] / 255f);
            colorTarget.GetComponent<Renderer>().material.color = newColor;
        }
    }
}
