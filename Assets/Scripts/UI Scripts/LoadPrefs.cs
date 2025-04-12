using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadPrefs : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private MenuButtons menuButtons;


    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeText = null;
    [SerializeField] private Slider volumeSlider = null;

    [Header("Brightness Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessText = null;

    [Header("Quality Settings")]
    [SerializeField] private TMP_Dropdown qualityDropdown;

    [Header("Fullscreen Settings")]
    [SerializeField] private Toggle fullScreenToggle;

    [Header("Sensitivity Settings")]
    [SerializeField] private TMP_Text controllerSensText = null;
    [SerializeField] private Slider controllerSensSlider = null;

    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeText.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                menuButtons.ResetButton("Audio");
            }

            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);
            }

            if (PlayerPrefs.HasKey("masterFullscreen"))
            {
                int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");
                
                if(localFullscreen == 1)
                {
                    Screen.fullScreen = true;
                    fullScreenToggle.isOn = true;

                }
                else
                {
                    Screen.fullScreen = false;
                    fullScreenToggle.isOn = false;
                }

                if (PlayerPrefs.HasKey("masterBrightness"))
                {
                    float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                    brightnessText.text = localBrightness.ToString("0.0");
                    brightnessSlider.value = localBrightness;
                }

                if (PlayerPrefs.HasKey("masterSens"))
                {
                    float localSens = PlayerPrefs.GetFloat("masterSens");
                    controllerSensSlider.value = localSens;
                    controllerSensText.text = localSens.ToString("0.0");
                    menuButtons.mainControllerSens = Mathf.RoundToInt(localSens);
                }
            }
        }        
    }

}
