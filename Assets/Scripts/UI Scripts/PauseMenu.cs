using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Reference to the pause menu UI panel
    public GameObject pauseMenuUI;

    // Bool to track if the game is paused
    public bool isPaused;

    void Start()
    {
        // Make sure the pause menu is hidden on start
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }

    void Update()
    {
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
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
        // Disable the pause menu UI
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }

        // Resume the game by setting timeScale to 1
        Time.timeScale = 1f;

        // Update the pause state
        isPaused = false;
    }

    private void Pause()
    {
        // Enable the pause menu UI
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }

        // Pause the game by setting timeScale to 0
        Time.timeScale = 0f;

        // Update the pause state
        isPaused = true;
    }
}