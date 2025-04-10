using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public GameObject settingsMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1 Whiteboxing EI 1");
    }

    public void GoToSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void SettingsToMain()
    {
        settingsMenu.SetActive(false);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
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
}
