using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensivity : MonoBehaviour
{
    public Toggle toggle;
    public Slider slider;
    public int brightness;
    public static float sensivity;
    public static int particles;
    public GameObject snow1;
    public GameObject snow2;
    // Start is called before the first frame update
    void Start()
    {
       Sensivity.sensivity = 1 / 2;
        slider.value = 1 / 2;
        if (PlayerPrefs.HasKey("sensivity"))
        {
            slider.value = PlayerPrefs.GetFloat("sensivity");
        }
        else slider.value = 1 / 2;
    }

    void SetBrightness(int brightness)
    {
    }
    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("sensivity", slider.value);
        if(toggle.isOn)
        PlayerPrefs.SetInt("particles", 1);
        else
        PlayerPrefs.SetInt("particles", 0);
    }
}