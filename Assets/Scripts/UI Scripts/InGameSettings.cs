using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class InGameSettings : MonoBehaviour
{
    private Vector3 startPoint = new Vector3(5f, 430.83f, 201.2f);
    public GameObject player;
    private Animator animator;
    [SerializeField] AudioClip deathClip;
    void Start()
    {
        animator = player.GetComponent<Animator>();
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
        StartCoroutine(LoadScene("GameOver"));
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator LoadScene(string sceneToLoad)
    {
        animator.SetTrigger("Death");    
        AudioSource.PlayClipAtPoint(deathClip, transform.position, 1f);
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
