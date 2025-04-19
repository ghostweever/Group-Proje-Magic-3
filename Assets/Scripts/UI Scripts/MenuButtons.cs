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


    [Header("Volume")]
    [SerializeField] private TMP_Text volumeText = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = .5f;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    [Header("Graphics")]

    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;

    private int qualityLevel;
    private bool isFullscreen;


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

        DataPersistenceManager.instance.SaveGame();

        SceneManager.LoadSceneAsync("Owasis Tutorial");
    }

    public void LoadGame()
    {
        DataPersistenceManager.instance.SaveGame();

        SceneManager.LoadSceneAsync("Hub");
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

   

    public void GamePlaySave()
    {
         
        StartCoroutine(Confirm());
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
            
            GamePlaySave();
        }

        if(MenuType == "Graphics")
        {

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
