using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class setting : MonoBehaviour
{
    public AudioMixer audiomixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setmaster(float sliderval) {
        audiomixer.SetFloat("masterpar", Mathf.Log10(sliderval)*20);
    }

    public void setbgm(float sliderval) {
        audiomixer.SetFloat("bgmpar", Mathf.Log10(sliderval)*20);
    }
    public void setsfx(float sliderval) {
        audiomixer.SetFloat("sfxpar", Mathf.Log10(sliderval)*20);
    }

}
