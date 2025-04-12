using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuButtons : MonoBehaviour
{

    [Header("Levels to Load")]
    public string newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSaveFile = null;


    [Header("Volume")]
    [SerializeField] private TMP_Text volumeText = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = .5f;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    [Header("Gameplay Settings")]
    [SerializeField] private TMP_Text controllerSensText = null;
    [SerializeField] private Slider controllerSensSlider = null;
    [SerializeField] private int defaultSens = 4;
    public int mainControllerSens = 4;

    [Header("Graphics")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessText = null;
    [SerializeField] private float defaultBrightness = 1;

    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;

    private int qualityLevel;
    private bool isFullscreen;
    private float brightnessLevel;

    [Header("Resolution")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    [Header("Buttons")]
    [SerializeField] private Button loadGame;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolution = i;
            }

            if (!DataPersistenceManager.instance.HasGameData())
            {
                loadGame.interactable = false;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolution;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void NewGame()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("Level1");
    }

    public void LoadGame()
    {
        

        SceneManager.LoadSceneAsync("Level1");
    }

    public void SaveGame() {
        DataPersistenceManager.instance.SaveGame();
    }

    

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Debug()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeText.text = volume.ToString("0.0");
    }

    

    public void VolumeSave()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(Confirm());

    }

    public void SetControllerSens(float sensitivity)
    {
        mainControllerSens = Mathf.RoundToInt(sensitivity);
        controllerSensText.text = sensitivity.ToString("0");
    }

    public void GamePlaySave()
    {
        PlayerPrefs.SetFloat("masterSens", mainControllerSens);
        StartCoroutine(Confirm());
    }

    public void SetBrightness(float brightness)
    {
        brightnessLevel = brightness;
        brightnessText.text = brightness.ToString("0.0");

    }

    public void SetFullscreen(bool _isFullscreen)
    {
        isFullscreen = _isFullscreen;
    }

    public void SetQuality(int quality)
    {
        qualityLevel = quality;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", brightnessLevel);
        PlayerPrefs.SetInt("masterQuality", qualityLevel);
        QualitySettings.SetQualityLevel(qualityLevel);

        PlayerPrefs.SetInt("masterFullscreen", (isFullscreen ? 1 : 0));
        Screen.fullScreen = isFullscreen;

        StartCoroutine(Confirm());
    }

    public void ResetButton(string MenuType)
    {
        if(MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeText.text = defaultVolume.ToString("0.0");
            VolumeSave();
        } 

        if(MenuType == "Gameplay")
        {
            controllerSensText.text = defaultSens.ToString("0");
            controllerSensSlider.value = defaultSens;
            mainControllerSens = defaultSens;
            GamePlaySave();
        }

        if(MenuType == "Graphics")
        {
            brightnessSlider.value = defaultBrightness;
            brightnessText.text = defaultBrightness.ToString("0.0");

            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);

            fullScreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply();
        }
    }

    public IEnumerator Confirm()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
