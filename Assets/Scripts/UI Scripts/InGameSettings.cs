using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameSettings : MonoBehaviour
{
    private Vector3 startPoint = new Vector3(5f, 430.83f, 201.2f);
    public GameObject player;
    void Start()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        GameObject.Find("PauseMenuUI").GetComponent<PauseMenu>().Resume();
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void SaveData()
    {
        GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().SaveGame();
    }

    public void TryAgain()
    {

        SceneManager.LoadSceneAsync("Hub");
        player.transform.position = startPoint;
    }
    public void Death()
    {
        SceneManager.LoadSceneAsync("GameOver");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
