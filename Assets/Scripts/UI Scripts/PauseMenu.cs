using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject pauseImage;
    public bool isPaused;
    public Button settings;

    void Start()
    {

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            pauseImage.SetActive(false);  
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("PauseMenuKeyBoard") || Input.GetButtonDown("PauseMenuXbox"))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            pauseImage.SetActive(false);
        }

        Time.timeScale = 1f;

        isPaused = false;
    }

    //Pauses time and turns pause menu on
    private void Pause()
    {

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            pauseImage.SetActive(true);
            settings.Select();
        }

        Time.timeScale = 0f;


        isPaused = true;
    }
}