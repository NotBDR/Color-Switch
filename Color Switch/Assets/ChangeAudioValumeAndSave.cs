using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAudioValumeAndSave : MonoBehaviour
{
    public AudioSource Music;
    public GameObject SliderInSide;
    private void Start()
    {
        Music.volume = PlayerPrefs.GetFloat("Music", 0.25f);
    }
    public void ChangeAudioAndSaveit() {
        Music.volume = SliderInSide.GetComponent<Slider>().value/4;
        PlayerPrefs.SetFloat("Music", SliderInSide.GetComponent<Slider>().value / 4);
    } 
}
