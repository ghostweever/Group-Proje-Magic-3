using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
   
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
