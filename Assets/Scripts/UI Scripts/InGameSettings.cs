using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameSettings : MonoBehaviour
{
    void Start()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void SaveData()
    {
        GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().SaveGame();
    }

    public void Death()
    {
        SceneManager.LoadSceneAsync("GameOver");
    }
}
