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
    public Dropdown qualityDropdown, resolutionDropdown;

    public Toggle fullscreenToggle;

    private int screenInt;
    private bool isFullscreen = false;

    const string Qvalue = "optionvalue";

    void Awake()
    {
        screenInt = PlayerPrefs.GetInt("togglestate");

        if (screenInt == 1)
        {
            isFullscreen = true;
            fullscreenToggle.isOn = true;
        }
        else
        {
            isFullscreen = false;
            fullscreenToggle.isOn = false;
        }


        qualityDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(Qvalue, qualityDropdown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        //volSlider.value = PlayerPrefs.GetFloat("MVolume");
        //volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));

        qualityDropdown.value = PlayerPrefs.GetInt(Qvalue, 3);

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

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (!isFullscreen)
        {
            PlayerPrefs.SetInt("togglestate", 0);
        }
        else
        {
            isFullscreen = true;
            PlayerPrefs.SetInt("togglestate", 1);
        }
    }
}
