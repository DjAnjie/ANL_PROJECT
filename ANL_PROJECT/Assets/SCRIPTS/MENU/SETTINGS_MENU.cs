using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SETTINGS_MENU : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer volMixer;
    public Slider volSlider;


    void Start()
    {
        //volSlider.value = PlayerPrefs.GetFloat("MVolume");
        //volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
    }
    public void ChangeVol(float volume)
    {
        PlayerPrefs.SetFloat("MVolume", volume);
        volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));

        if (PlayerPrefs.GetFloat("MVolume") < -4)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }

}
