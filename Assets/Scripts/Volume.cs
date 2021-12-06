using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider Volslider;
    public AudioSource audio1;

    private float Vol = 1f;

    void Start()
    {
        Vol = PlayerPrefs.GetFloat("vol", 1f);
        Volslider.value = Vol;
        audio1.volume = Volslider.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }
    public void SoundSlider()
    {
        audio1.volume = Volslider.value;
        Vol = Volslider.value;
        PlayerPrefs.SetFloat("vol", Vol);
    }
}
