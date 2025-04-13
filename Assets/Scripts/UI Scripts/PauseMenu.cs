using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public bool isPaused;

    void Start()
    {

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("PauseMenuKeyboard") || Input.GetButtonDown("PauseMenuXbox"))
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
        }

        Time.timeScale = 0f;


        isPaused = true;
    }
}